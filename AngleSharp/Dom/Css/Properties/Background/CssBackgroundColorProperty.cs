﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/background-color
    /// </summary>
    sealed class CssBackgroundColorProperty : CssProperty, ICssBackgroundColorProperty
    {
        #region Fields

        internal static readonly Color Default = Color.Transparent;
        internal static readonly IValueConverter<Color> Converter = Converters.ColorConverter.WithCurrentColor();
        Color _color;

        #endregion

        #region ctor

        internal CssBackgroundColorProperty(CssStyleDeclaration rule)
            : base(PropertyNames.BackgroundColor, rule, PropertyFlags.Hashless | PropertyFlags.Animatable)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the color of the background.
        /// </summary>
        /// <returns></returns>
        public Color Color
        {
            get { return _color; }
        }

        #endregion

        #region Methods

        public void SetColor(Color color)
        {
            _color = color;
        }

        internal override void Reset()
        {
            _color = Default;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(ICssValue value)
        {
            return Converter.TryConvert(value, SetColor);
        }

        #endregion
    }
}
