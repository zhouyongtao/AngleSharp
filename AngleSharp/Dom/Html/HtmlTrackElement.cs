﻿namespace AngleSharp.Dom.Html
{
    using AngleSharp.Dom.Media;
    using AngleSharp.Html;
    using System;

    /// <summary>
    /// Represents the HTML track element.
    /// </summary>
    sealed class HtmlTrackElement : HtmlElement, IHtmlTrackElement
    {
        #region Fields

        readonly BoundLocation _src;
        TrackReadyState _ready;

        #endregion

        #region ctor

        /// <summary>
        /// Creates a new HTML track element.
        /// </summary>
        public HtmlTrackElement(Document owner)
            : base(owner, Tags.Track, NodeFlags.Special | NodeFlags.SelfClosing)
        {
            _src = new BoundLocation(this, AttributeNames.Src);
            _ready = TrackReadyState.None;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the kind of the track.
        /// </summary>
        public String Kind
        {
            get { return GetAttribute(AttributeNames.Kind); }
            set { SetAttribute(AttributeNames.Kind, value); }
        }

        /// <summary>
        /// Gets or sets the media source.
        /// </summary>
        public String Source
        {
            get { return _src.Href; }
            set { _src.Href = value; }
        }

        /// <summary>
        /// Gets or sets the language of the source.
        /// </summary>
        public String SourceLanguage
        {
            get { return GetAttribute(AttributeNames.SrcLang); }
            set { SetAttribute(AttributeNames.SrcLang, value); }
        }

        /// <summary>
        /// Gets or sets the label text.
        /// </summary>
        public String Label
        {
            get { return GetAttribute(AttributeNames.Label); }
            set { SetAttribute(AttributeNames.Label, value); }
        }

        /// <summary>
        /// Gets or sets if given track is the default track.
        /// </summary>
        public Boolean IsDefault
        {
            get { return GetAttribute(AttributeNames.Default) != null; }
            set { SetAttribute(AttributeNames.Default, value ? String.Empty : null); }
        }

        /// <summary>
        /// Gets the ready state of the given track.
        /// </summary>
        public TrackReadyState ReadyState
        {
            get { return _ready; }
        }

        public ITextTrack Track
        {
            get { return null; }
        }

        #endregion

        #region Enumeration

        /// <summary>
        /// An enumeration with various track kinds.
        /// </summary>
        public enum TrackKind : ushort
        {
            /// <summary>
            /// A track with subtitles.
            /// </summary>
            Subtitles,
            /// <summary>
            /// A track with captions.
            /// </summary>
            Captions,
            /// <summary>
            /// A track with descriptions.
            /// </summary>
            Descriptions,
            /// <summary>
            /// A track consisting of chapters.
            /// </summary>
            Chapters,
            /// <summary>
            /// A track consisting only of metadata.
            /// </summary>
            Metadata
        }

        #endregion
    }
}
