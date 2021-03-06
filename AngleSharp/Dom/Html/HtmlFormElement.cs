﻿namespace AngleSharp.Dom.Html
{
    using AngleSharp.Dom.Collections;
    using AngleSharp.Extensions;
    using AngleSharp.Html;
    using AngleSharp.Network;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the form element.
    /// </summary>
    sealed class HtmlFormElement : HtmlElement, IHtmlFormElement, IDisposable
    {
        #region Fields

        static readonly String UsAscii = "us-ascii";

        HtmlFormControlsCollection _elements;
        Task<IDocument> _navigationTask;
        CancellationTokenSource _cts;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new HTML form element.
        /// </summary>
        public HtmlFormElement(Document owner)
            : base(owner, Tags.Form, NodeFlags.Special)
        {
            _cts = new CancellationTokenSource();
        }

        #endregion

        #region Index

        /// <summary>
        /// Gets the form element at the specified index.
        /// </summary>
        /// <param name="index">The index in the elements collection.</param>
        /// <returns>The element or null.</returns>
        public IElement this[Int32 index]
        {
            get { return Elements[index]; }
        }

        /// <summary>
        /// Gets the form element(s) with the specified name.
        /// </summary>
        /// <param name="name">The name or id of the element.</param>
        /// <returns>A collection with elements, an element or null.</returns>
        public IElement this[String name]
        {
            get { return Elements[name]; }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the name attribute.
        /// </summary>
        public String Name
        {
            get { return GetAttribute(AttributeNames.Name); }
            set { SetAttribute(AttributeNames.Name, value); }
        }

        /// <summary>
        /// Gets the number of elements in the Elements collection.
        /// </summary>
        public Int32 Length
        {
            get { return Elements.Length; }
        }

        /// <summary>
        /// Gets all the form controls belonging to this form element.
        /// </summary>
        public HtmlFormControlsCollection Elements
        {
            get { return _elements ?? (_elements = new HtmlFormControlsCollection(this)); }
        }

        /// <summary>
        /// Gets all the form controls belonging to this form element.
        /// </summary>
        IHtmlFormControlsCollection IHtmlFormElement.Elements
        {
            get { return Elements; }
        }

        /// <summary>
        /// Gets or sets the character encodings that are to be used for the submission.
        /// </summary>
        public String AcceptCharset
        {
            get { return GetAttribute(AttributeNames.AcceptCharset); }
            set { SetAttribute(AttributeNames.AcceptCharset, value); }
        }

        /// <summary>
        /// Gets or sets the form's name within the forms collection.
        /// </summary>
        public String Action
        {
            get { return GetAttribute(AttributeNames.Action); }
            set { SetAttribute(AttributeNames.Action, value); }
        }

        /// <summary>
        /// Gets or sets if autocomplete is turned on or off.
        /// </summary>
        public String Autocomplete
        {
            get { return GetAttribute(AttributeNames.AutoComplete); }
            set { SetAttribute(AttributeNames.AutoComplete, value); }
        }

        /// <summary>
        /// Gets or sets the encoding to use for sending the form.
        /// </summary>
        public String Enctype
        {
            get { return CheckEncType(GetAttribute(AttributeNames.Enctype)); }
            set { SetAttribute(AttributeNames.Enctype, CheckEncType(value)); }
        }

        /// <summary>
        /// Gets or sets the encoding to use for sending the form.
        /// </summary>
        public String Encoding
        {
            get { return Enctype; }
            set { Enctype = value; }
        }

        /// <summary>
        /// Gets or sets the method to use for transmitting the form.
        /// </summary>
        public String Method
        {
            get { return GetAttribute(AttributeNames.Method) ?? String.Empty; }
            set { SetAttribute(AttributeNames.Method, value); }
        }

        /// <summary>
        /// Gets or sets the indicator that the form is not to be validated during submission.
        /// </summary>
        public Boolean NoValidate
        {
            get { return GetAttribute(AttributeNames.NoValidate) != null; }
            set { SetAttribute(AttributeNames.NoValidate, value ? String.Empty : null); }
        }

        /// <summary>
        /// Gets or sets the target name of the response to the request.
        /// </summary>
        public String Target
        {
            get { return GetAttribute(AttributeNames.Target); }
            set { SetAttribute(AttributeNames.Target, value); }
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            if (_cts != null)
                _cts.Cancel();

            _cts = null;
            _navigationTask = null;
        }

        /// <summary>
        /// Submits the form element from the form element itself.
        /// </summary>
        public Task<IDocument> Submit()
        {
            SubmitForm(this, true);
            return _navigationTask;
        }

        /// <summary>
        /// Resets the form to the previous (default) state.
        /// </summary>
        public void Reset()
        {
            foreach (var element in Elements)
                element.Reset();
        }

        /// <summary>
        /// Checks if the form is valid, i.e. if all fields fulfill their requirements.
        /// </summary>
        /// <returns>True if the form is valid, otherwise false.</returns>
        public Boolean CheckValidity()
        {
            var controls = GetInvalidControls();
            var result = true;

            foreach (var control in controls)
            {
                if (control.FireSimpleEvent(EventNames.Invalid, false, true) == false)
                    result = false;
            }

            return result;
        }

        /// <summary>
        /// Evaluates the form controls according to the spec:
        /// https://html.spec.whatwg.org/multipage/forms.html#statically-validate-the-constraints
        /// </summary>
        /// <returns>A list over all invalid controls.</returns>
        IEnumerable<HtmlFormControlElement> GetInvalidControls()
        {
            foreach (var element in Elements)
            {
                if (element.WillValidate && element.CheckValidity() == false)
                    yield return element;
            }
        }

        public Boolean ReportValidity()
        {
            var controls = GetInvalidControls();
            var result = true;
            var hasfocused = false;

            foreach (var control in controls)
            {
                if (control.FireSimpleEvent(EventNames.Invalid, false, true))
                    continue;

                if (hasfocused == false)
                {
                    //TODO Report Problems (interactively, e.g. via UI specific event)
                    control.DoFocus();
                    hasfocused = true;
                }

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Requests the input fields to be automatically filled with previous entries.
        /// </summary>
        public void RequestAutocomplete()
        {
            //TODO see:
            //http://www.whatwg.org/specs/web-apps/current-work/multipage/association-of-controls-and-forms.html#dom-form-requestautocomplete
        }

        #endregion

        #region Helpers

        void SubmitForm(HtmlElement from, Boolean submittedFromSubmitMethod)
        {
            var owner = Owner;
            var browsingContext = owner.Context;

            if (owner.ActiveSandboxing.HasFlag(Sandboxes.Forms))
                return;

            if (!submittedFromSubmitMethod && !from.Attributes.Any(m => m.Name == AttributeNames.FormNoValidate) && NoValidate)
            {
                if (!CheckValidity())
                {
                    this.FireSimpleEvent(EventNames.Invalid);
                    return;
                }
            }

            var action = String.IsNullOrEmpty(Action) ? new Url(owner.DocumentUri) : this.HyperReference(Action);
            var createdBrowsingContext = false;
            var targetBrowsingContext = owner.Context;
            var target = Target;

            if (!String.IsNullOrEmpty(target))
            {
                targetBrowsingContext = owner.GetTarget(target);

                if (createdBrowsingContext = (targetBrowsingContext == null))
                    targetBrowsingContext = owner.CreateTarget(target);
            }

            var replace = createdBrowsingContext || owner.ReadyState != DocumentReadyState.Complete;
            var scheme = action.Scheme;
            var method = Method.ToEnum(HttpMethod.Get);

            if (scheme == KnownProtocols.Http || scheme == KnownProtocols.Https)
            {
                if (method == HttpMethod.Get)
                    MutateActionUrl(action);
                else if (method == HttpMethod.Post)
                    SubmitAsEntityBody(action);
            }
            else if (scheme == KnownProtocols.Data)
            {
                if (method == HttpMethod.Get)
                    GetActionUrl(action);
                else if (method == HttpMethod.Post)
                    PostToData(action);
            }
            else if (scheme == KnownProtocols.Mailto)
            {
                if (method == HttpMethod.Get)
                    MailWithHeaders(action);
                else if (method == HttpMethod.Post)
                    MailAsBody(action);
            }
            else if (scheme == KnownProtocols.Ftp || scheme == KnownProtocols.JavaScript)
            {
                GetActionUrl(action);
            }
            else
            {
                MutateActionUrl(action);
            }
        }

        /// <summary>
        /// More information can be found at:
        /// http://www.w3.org/html/wg/drafts/html/master/forms.html#submit-data-post
        /// </summary>
        void PostToData(Url action)
        {
            var encoding = String.IsNullOrEmpty(AcceptCharset) ? Owner.CharacterSet : AcceptCharset;
            var formDataSet = ConstructDataSet();
            var enctype = Enctype;
            var result = String.Empty;

            if (enctype.Equals(MimeTypes.StandardForm, StringComparison.OrdinalIgnoreCase))
            {
                using (var sr = new StreamReader(formDataSet.AsUrlEncoded(TextEncoding.Resolve(encoding))))
                    result = sr.ReadToEnd();
            }
            else if (enctype.Equals(MimeTypes.MultipartForm, StringComparison.OrdinalIgnoreCase))
            {
                using (var sr = new StreamReader(formDataSet.AsMultipart(TextEncoding.Resolve(encoding))))
                    result = sr.ReadToEnd();
            }
            else if (enctype.Equals(MimeTypes.Plain, StringComparison.OrdinalIgnoreCase))
            {
                using (var sr = new StreamReader(formDataSet.AsPlaintext(TextEncoding.Resolve(encoding))))
                    result = sr.ReadToEnd();
            }

            if (action.Href.Contains("%%%%"))
            {
                result = result.UrlEncode(TextEncoding.Resolve(UsAscii));
                action.Href = action.Href.ReplaceFirst("%%%%", result);
            }
            else if (action.Href.Contains("%%"))
            {
                result = result.UrlEncode(TextEncoding.Utf8);
                action.Href = action.Href.ReplaceFirst("%%", result);
            }

            _navigationTask = NavigateTo(action, HttpMethod.Get);
        }

        /// <summary>
        /// More information can be found at:
        /// http://www.w3.org/html/wg/drafts/html/master/forms.html#submit-mailto-headers
        /// </summary>
        void MailWithHeaders(Url action)
        {
            var formDataSet = ConstructDataSet();
            var result = formDataSet.AsUrlEncoded(TextEncoding.Resolve(UsAscii));
            var headers = String.Empty;

            using (var sr = new StreamReader(result))
                headers = sr.ReadToEnd();

            action.Query = headers.Replace("+", "%20");
            GetActionUrl(action);
        }

        /// <summary>
        /// More information can be found at:
        /// http://www.w3.org/html/wg/drafts/html/master/forms.html#submit-mailto-body
        /// </summary>
        void MailAsBody(Url action)
        {
            var formDataSet = ConstructDataSet();
            var enctype = Enctype;
            var encoding = TextEncoding.Resolve(UsAscii);
            var body = String.Empty;

            if (enctype.Equals(MimeTypes.StandardForm, StringComparison.OrdinalIgnoreCase))
            {
                using (var sr = new StreamReader(formDataSet.AsUrlEncoded(encoding)))
                    body = sr.ReadToEnd();
            }
            else if (enctype.Equals(MimeTypes.MultipartForm, StringComparison.OrdinalIgnoreCase))
            {
                using (var sr = new StreamReader(formDataSet.AsMultipart(encoding)))
                    body = sr.ReadToEnd();
            }
            else if (enctype.Equals(MimeTypes.Plain, StringComparison.OrdinalIgnoreCase))
            {
                using (var sr = new StreamReader(formDataSet.AsPlaintext(encoding)))
                    body = sr.ReadToEnd();
            }

            action.Query = "body=" + body.UrlEncode(encoding);
            GetActionUrl(action);
        }

        /// <summary>
        /// More information can be found at:
        /// http://www.w3.org/html/wg/drafts/html/master/forms.html#submit-get-action
        /// </summary>
        void GetActionUrl(Url action)
        {
            _navigationTask = NavigateTo(action, HttpMethod.Get);
        }

        /// <summary>
        /// Submits the body of the form.
        /// http://www.w3.org/html/wg/drafts/html/master/forms.html#submit-body
        /// </summary>
        void SubmitAsEntityBody(Url action)
        {
            var encoding = String.IsNullOrEmpty(AcceptCharset) ? Owner.CharacterSet : AcceptCharset;
            var formDataSet = ConstructDataSet();
            var enctype = Enctype;
            var mimeType = String.Empty;
            Stream result = null;

            if (enctype.Equals(MimeTypes.StandardForm, StringComparison.OrdinalIgnoreCase))
            {
                result = formDataSet.AsUrlEncoded(TextEncoding.Resolve(encoding));
                mimeType = MimeTypes.StandardForm;
            }
            else if (enctype.Equals(MimeTypes.MultipartForm, StringComparison.OrdinalIgnoreCase))
            {
                result = formDataSet.AsMultipart(TextEncoding.Resolve(encoding));
                mimeType = String.Concat(MimeTypes.MultipartForm, "; boundary=", formDataSet.Boundary);
            }
            else if (enctype.Equals(MimeTypes.Plain, StringComparison.OrdinalIgnoreCase))
            {
                result = formDataSet.AsPlaintext(TextEncoding.Resolve(encoding));
                mimeType = MimeTypes.Plain;
            }

            _navigationTask = NavigateTo(action, HttpMethod.Post, result, mimeType);
        }

        /// <summary>
        /// Plan to navigate to an action using the specified method with the given
        /// entity body of the mime type.
        /// http://www.w3.org/html/wg/drafts/html/master/forms.html#plan-to-navigate
        /// </summary>
        /// <param name="action">The action to use.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="body">The entity body of the request.</param>
        /// <param name="mime">The MIME type of the entity body.</param>
        async Task<IDocument> NavigateTo(Url action, HttpMethod method, Stream body = null, String mime = null)
        {
            if (_navigationTask != null)
            {
                _cts.Cancel();
                _navigationTask = null;
                _cts = new CancellationTokenSource();
            }

            var requester = Owner.Options.GetRequester(action.Scheme);

            if (requester != null)
            {
                using (var response = await requester.SendAsync(action, body, mime, method, _cts.Token).ConfigureAwait(false))
                    return await Owner.Context.OpenAsync(response, _cts.Token).ConfigureAwait(false);
            }

            return null;
        }

        /// <summary>
        /// More information can be found at:
        /// http://www.w3.org/html/wg/drafts/html/master/forms.html#submit-mutate-action
        /// </summary>
        void MutateActionUrl(Url action)
        {
            var encoding = String.IsNullOrEmpty(AcceptCharset) ? Owner.CharacterSet : AcceptCharset;
            var formDataSet = ConstructDataSet();
            var result = formDataSet.AsUrlEncoded(TextEncoding.Resolve(encoding));

            using (var sr = new StreamReader(result))
                action.Query = sr.ReadToEnd();

            GetActionUrl(action);
        }

        /// <summary>
        /// Constructs the form data set with the given submitter.
        /// </summary>
        /// <param name="submitter">[Optional] The submitter to use.</param>
        /// <returns>The constructed form data set.</returns>
        FormDataSet ConstructDataSet(HtmlElement submitter = null)
        {
            var formDataSet = new FormDataSet();

            foreach (var field in Elements)
            {
                if (field.ParentElement is IHtmlDataListElement)
                    continue;
                else if (field.IsDisabled)
                    continue;

                field.ConstructDataSet(formDataSet, submitter);
            }

            return formDataSet;
        }

        /// <summary>
        /// Checks the encoding type of the form and returns the appropriate
        /// encoding type, which is either the given one, or the default one.
        /// </summary>
        /// <param name="encType">The encoding type used by the form.</param>
        /// <returns>A valid encoding type.</returns>
        String CheckEncType(String encType)
        {
            if (!String.IsNullOrEmpty(encType) && (encType.Equals(MimeTypes.Plain, StringComparison.OrdinalIgnoreCase) || encType.Equals(MimeTypes.MultipartForm, StringComparison.OrdinalIgnoreCase)))
                return encType;

            return MimeTypes.StandardForm;
        }

        #endregion
    }
}
