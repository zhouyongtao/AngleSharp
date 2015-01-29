﻿namespace AngleSharp.Dom.Html
{
    using AngleSharp.Extensions;
    using AngleSharp.Html;
    using AngleSharp.Infrastructure;
    using AngleSharp.Network;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an HTML script element.
    /// </summary>
    sealed class HtmlScriptElement : HtmlElement, IHtmlScriptElement
    {
        #region Fields

        Boolean _started;
        Boolean _parserInserted;
        Boolean _wasParserInserted;
        Boolean _forceAsync;
        Boolean _readyToBeExecuted;
        Task<IResponse> _load;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new HTML script element.
        /// </summary>
        public HtmlScriptElement(Document owner)
            : base(owner, Tags.Script, NodeFlags.Special | NodeFlags.LiteralText)
        {
        }

        #endregion

        #region Internal Properties

        internal Boolean IsReady
        {
            get { return _readyToBeExecuted; }
        }

        internal Boolean IsParserInserted 
        {
            get { return _parserInserted; }
            set { _parserInserted = value; }
        }

        internal Boolean IsAlreadyStarted
        {
            get { return _started; }
            set { _started = value; }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the language of the script.
        /// </summary>
        public String ScriptLanguage
        {
            get
            {
                var type = Type ?? (GetAttribute(AttributeNames.Language) != null ? "text/" + GetAttribute(AttributeNames.Language) : null);

                if (String.IsNullOrEmpty(type))
                    return MimeTypes.DefaultJavaScript;

                return type;
            }
        }

        /// <summary>
        /// Gets or sets athe address of the resource.
        /// </summary>
        public String Source
        {
            get { return GetAttribute(AttributeNames.Src); }
            set { SetAttribute(AttributeNames.Src, value); }
        }

        /// <summary>
        /// Gets or sets the type of an embedded resource.
        /// </summary>
        public String Type
        {
            get { return GetAttribute(AttributeNames.Type); }
            set { SetAttribute(AttributeNames.Type, value); }
        }

        /// <summary>
        /// Gets or sets the character encoding of the external script resource.
        /// </summary>
        public String CharacterSet
        {
            get { return GetAttribute(AttributeNames.Charset); }
            set { SetAttribute(AttributeNames.Charset, value); }
        }

        /// <summary>
        /// Gets or sets the text in the script element.
        /// </summary>
        public String Text
        {
            get { return TextContent; }
            set { TextContent = value; }
        }

        /// <summary>
        /// Gets or sets how the element handles crossorigin requests.
        /// </summary>
        public String CrossOrigin
        {
            get { return GetAttribute(AttributeNames.CrossOrigin); }
            set { SetAttribute(AttributeNames.CrossOrigin, value); }
        }

        /// <summary>
        /// Gets or sets if the script should be deferred.
        /// </summary>
        public Boolean IsDeferred
        {
            get { return GetAttribute(AttributeNames.Defer) != null; }
            set { SetAttribute(AttributeNames.Defer, value ? String.Empty : null); }
        }

        /// <summary>
        /// Gets or sets if script should execute asynchronously.
        /// </summary>
        public Boolean IsAsync
        {
            get { return GetAttribute(AttributeNames.Async) != null; }
            set { SetAttribute(AttributeNames.Async, value ? String.Empty : null); }
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// More information available at:
        /// http://www.w3.org/TR/html5/scripting-1.html#execute-the-script-block
        /// </summary>
        internal void Run()
        {
            var owner = Owner;

            if (_load == null || owner == null)
                return;

            if (_load.Exception != null || _load.IsFaulted)
            {
                Error();
                return;
            }

            if (CancelledBeforeScriptExecute())
                return;

            using (var result = _load.Result)
                owner.Options.RunScript(result, CreateOptions(), ScriptLanguage);

            AfterScriptExecute();

            if (Source != null) Load();
            else owner.QueueTask(Load);
        }

        /// <summary>
        /// More information available at:
        /// http://www.w3.org/TR/html5/scripting-1.html#prepare-a-script
        /// </summary>
        internal void Prepare()
        {
            var owner = Owner;

            if (_started || owner == null)
                return;

            var options = owner.Options;

            _wasParserInserted = _parserInserted;
            _parserInserted = false;

            _forceAsync = _wasParserInserted && !IsAsync;

            if ((String.IsNullOrEmpty(Source) && String.IsNullOrEmpty(Text)) || owner == null)
                return;

            if (options.GetScriptEngine(ScriptLanguage) == null)
                return;

            if (_wasParserInserted)
            {
                _parserInserted = true;
                _forceAsync = false;
            }

            _started = true;

            if (!owner.Options.IsScripting)
                return;

            var eventAttr = GetAttribute(AttributeNames.Event);
            var forAttr = GetAttribute(AttributeNames.For);

            if (!String.IsNullOrEmpty(eventAttr) && !String.IsNullOrEmpty(forAttr))
            {
                eventAttr = eventAttr.Trim();
                forAttr = forAttr.Trim();

                if (eventAttr.EndsWith("()"))
                    eventAttr = eventAttr.Substring(0, eventAttr.Length - 2);

                if (!forAttr.Equals(AttributeNames.Window, StringComparison.OrdinalIgnoreCase) || !eventAttr.Equals("onload", StringComparison.OrdinalIgnoreCase))
                    return;
            }

            var src = Source;

            if (src != null)
            {
                if (src == String.Empty)
                {
                    owner.QueueTask(Error);
                    return;
                }

                var url = this.HyperReference(src);
                var requester = options.GetRequester(url.Scheme);

                if (requester == null)
                    return;

                _load = requester.LoadWithCorsAsync(url, CrossOrigin.ToEnum(CorsSetting.None), owner.Origin, OriginBehavior.Taint);

                if (_parserInserted && !IsAsync)
                {
                    if (IsDeferred)
                        owner.AddScript(this);

                    _load.ContinueWith(task => _readyToBeExecuted = true);
                }
                else if (!IsAsync && !_forceAsync)
                {
                    //Add to end of list of scripts (in order) --> sufficient
                    owner.AddScript(this);
                }
                else
                {
                    //Just add to the set of scripts
                    owner.AddScript(this);
                }
            }
            else if (_parserInserted && owner.HasScriptBlockingStyleSheet())
            {
                _readyToBeExecuted = true;
            }
            else
            {
                options.RunScript(Text, CreateOptions(), ScriptLanguage);
            }
        }

        void Load()
        {
            this.FireSimpleEvent(EventNames.Load);
        }

        void Error()
        {
            this.FireSimpleEvent(EventNames.Error);
        }

        Boolean CancelledBeforeScriptExecute()
        {
            return this.FireSimpleEvent(EventNames.BeforeScriptExecute, cancelable: true);
        }

        void AfterScriptExecute()
        {
            this.FireSimpleEvent(EventNames.AfterScriptExecute, bubble: true);
        }

        ScriptOptions CreateOptions()
        {
            return new ScriptOptions
            {
                Context = Owner.DefaultView,
                Document = Owner,
                Element = this,
                Encoding = DocumentEncoding.Resolve(CharacterSet)
            };
        }

        #endregion
    }
}