﻿namespace AngleSharp.Dom.Html
{
    using AngleSharp.Extensions;
    using AngleSharp.Html;
    using AngleSharp.Services.Media;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the image element.
    /// </summary>
    sealed class HtmlImageElement : HtmlElement, IHtmlImageElement, IDisposable
    {
        #region Fields

        readonly BoundLocation _src;
        CancellationTokenSource _cts;
        Task<IImageInfo> _imageTask;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new image element.
        /// </summary>
        public HtmlImageElement(Document owner)
            : base(owner, Tags.Img, NodeFlags.Special | NodeFlags.SelfClosing)
        {
            _src = new BoundLocation(this, AttributeNames.Src);
            RegisterAttributeObserver(AttributeNames.Src, UpdateSource);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the actual used image source.
        /// </summary>
        public String ActualSource
        {
            get { return Source;  }
        }

        /// <summary>
        /// Gets or sets the image candidates for higher density images.
        /// </summary>
        public String SourceSet
        {
            get { return GetAttribute(AttributeNames.SrcSet); }
            set { SetAttribute(AttributeNames.SrcSet, value); }
        }

        /// <summary>
        /// Gets or sets the sizes to responsively.
        /// </summary>
        public String Sizes
        {
            get { return GetAttribute(AttributeNames.Sizes); }
            set { SetAttribute(AttributeNames.Sizes, value); }
        }

        /// <summary>
        /// Gets or sets the image source.
        /// </summary>
        public String Source
        {
            get { return _src.Href; }
            set { _src.Href = value; }
        }

        /// <summary>
        /// Gets or sets the alternative text.
        /// </summary>
        public String AlternativeText
        {
            get { return GetAttribute(AttributeNames.Alt); }
            set { SetAttribute(AttributeNames.Alt, value); }
        }

        /// <summary>
        /// Gets or sets the cross-origin attribute.
        /// </summary>
        public String CrossOrigin
        {
            get { return GetAttribute(AttributeNames.CrossOrigin); }
            set { SetAttribute(AttributeNames.CrossOrigin, value); }
        }

        /// <summary>
        /// Gets or sets the usemap attribute, which indicates that the image
        /// has an associated image map.
        /// </summary>
        public String UseMap
        {
            get { return GetAttribute(AttributeNames.UseMap); }
            set { SetAttribute(AttributeNames.UseMap, value); }
        }

        /// <summary>
        /// Gets or sets the displayed width of the image element.
        /// </summary>
        public Int32 DisplayWidth
        {
            get { return GetAttribute(AttributeNames.Width).ToInteger(OriginalWidth); }
            set { SetAttribute(AttributeNames.Width, value.ToString()); }
        }

        /// <summary>
        /// Gets or sets the displayed height of the image element.
        /// </summary>
        public Int32 DisplayHeight
        {
            get { return GetAttribute(AttributeNames.Height).ToInteger(OriginalHeight); }
            set { SetAttribute(AttributeNames.Height, value.ToString()); }
        }

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        public Int32 OriginalWidth
        {
            get { return _imageTask != null ? (_imageTask.IsCompleted && _imageTask.Result != null ? _imageTask.Result.Width : 0) : 0; }
        }

        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        public Int32 OriginalHeight
        {
            get { return _imageTask != null ? (_imageTask.IsCompleted && _imageTask.Result != null ? _imageTask.Result.Height : 0) : 0; }
        }

        /// <summary>
        /// Gets if the image is completely available.
        /// </summary>
        public Boolean IsCompleted
        {
            get { return _imageTask == null || _imageTask.IsCompleted; }
        }

        /// <summary>
        /// Gets or sets if the image element is a map. The attribute must not
        /// be specified on an element that does not have an ancestor a element
        /// with an href attribute.
        /// </summary>
        public Boolean IsMap
        {
            get { return GetAttribute(AttributeNames.IsMap) != null; }
            set { SetAttribute(AttributeNames.IsMap, value ? String.Empty : null); }
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            if (_cts != null)
                _cts.Cancel();

            _cts = null;
            _imageTask = null;
        }

        void UpdateSource(String value)
        {
            if (_cts != null)
                _cts.Cancel();

            if (!String.IsNullOrEmpty(value))
            {
                var url = new Url(ActualSource);
                //TODO Implement with srcset etc. --> see:
                //http://www.w3.org/html/wg/drafts/html/master/embedded-content.html#update-the-image-data
                _cts = new CancellationTokenSource();
                _imageTask = LoadAsync(url, _cts.Token);
            }
        }

        async Task<IImageInfo> LoadAsync(Url image, CancellationToken cancel)
        {
            var info = await Owner.Options.LoadResource<IImageInfo>(image, cancel).ConfigureAwait(false);
            this.FireSimpleEvent(EventNames.Load);
            return info;
        }

        #endregion
    }
}
