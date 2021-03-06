﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-repeat
    /// </summary>
    sealed class CssBorderImageRepeatProperty : CssProperty, ICssBorderImageRepeatProperty
    {
        #region Fields

        internal static readonly BorderRepeat Default = BorderRepeat.Stretch;
        internal static readonly IValueConverter<BorderRepeat[]> Converter = Map.BorderRepeatModes.ToConverter().Many(1, 2);
        BorderRepeat _horizontal;
        BorderRepeat _vertical;

        #endregion

        #region ctor

        internal CssBorderImageRepeatProperty(CssStyleDeclaration rule)
            : base(PropertyNames.BorderImageRepeat, rule)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the horizontal repeat value.
        /// </summary>
        public BorderRepeat Horizontal
        {
            get { return _horizontal; }
        }

        /// <summary>
        /// Gets the vertical repeat value.
        /// </summary>
        public BorderRepeat Vertical
        {
            get { return _vertical; }
        }

        #endregion

        #region Methods

        void SetRepeat(BorderRepeat horizontal, BorderRepeat vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
        }

        internal override void Reset()
        {
            _horizontal = Default;
            _vertical = Default;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(ICssValue value)
        {
            return Converter.TryConvert(value, m => SetRepeat(m[0], m.Length == 2 ? m[1] : m[0]));
        }

        #endregion
    }
}
