﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent
    /// </summary>
    sealed class CssTextIndentProperty : CssProperty, ICssTextIndentProperty
    {
        #region Fields

        internal static readonly Length Default = Length.Zero;
        internal static readonly IValueConverter<Length> Converter = Converters.LengthOrPercentConverter;
        Length _indent;

        #endregion

        #region ctor

        internal CssTextIndentProperty(CssStyleDeclaration rule)
            : base(PropertyNames.TextIndent, rule, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the indentation, which is either a percentage of the containing block width
        /// or specified as fixed length. Negative values are allowed.
        /// </summary>
        public Length Indent
        {
            get { return _indent; }
        }

        #endregion

        #region Methods

        public void SetIndent(Length indent)
        {
            _indent = indent;
        }

        internal override void Reset()
        {
            _indent = Default;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(ICssValue value)
        {
            return Converter.TryConvert(value, SetIndent);
        }

        #endregion
    }
}
