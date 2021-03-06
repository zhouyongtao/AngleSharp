﻿namespace AngleSharp.Dom.Html
{
    using AngleSharp.Html;
    using System;

    /// <summary>
    /// The time HTML element.
    /// </summary>
    sealed class HtmlTimeElement : HtmlElement, IHtmlTimeElement
    {
        #region ctor

        public HtmlTimeElement(Document owner)
            : base(owner, Tags.Time, NodeFlags.Special)
        {
        }

        #endregion

        #region Properties

        public String DateTime
        {
            get { return GetAttribute(AttributeNames.Datetime); }
            set { SetAttribute(AttributeNames.Datetime, value); }
        }

        #endregion
    }
}
