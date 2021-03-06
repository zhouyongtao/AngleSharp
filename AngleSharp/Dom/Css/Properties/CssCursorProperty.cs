﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Css.Values;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/cursor
    /// </summary>
    sealed class CssCursorProperty : CssProperty, ICssCursorProperty
    {
        #region Fields

        static readonly IValueConverter<Tuple<CustomCursor[], SystemCursor>> Converter = Converters.ImageSourceConverter.To(m => new CustomCursor { Image = m }).Or(
            Converters.WithOrder(
                Converters.ImageSourceConverter.Required(),
                Converters.NumberConverter.Required(),
                Converters.NumberConverter.Required()).To(
            v => new CustomCursor { Image = v.Item1, X = v.Item2, Y = v.Item3 })).FromList().RequiresEnd(Map.Cursors.ToConverter());
        static readonly SystemCursor Default = SystemCursor.Auto;

        CustomCursor[] _customs;
        SystemCursor _system;

        #endregion

        #region ctor

        internal CssCursorProperty(CssStyleDeclaration rule)
            : base(PropertyNames.Cursor, rule, PropertyFlags.Inherited)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected system cursor, if any.
        /// </summary>
        public SystemCursor Cursor
        {
            get { return _system; }
        }

        #endregion

        #region Methods

        internal override void Reset()
        {
            _customs = new CustomCursor[0];
            _system = Default;
        }

        void SetCursor(CustomCursor[] customs, SystemCursor system)
        {
            _customs = customs;
            _system = system;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(ICssValue value)
        {
            return Converter.TryConvert(value, nv => SetCursor(nv.Item1, nv.Item2));
        }

        #endregion

        #region Custom Cursor

        /// <summary>
        /// A url pointing to an image file.
        /// </summary>
        struct CustomCursor
        {
            public IImageSource Image;
            public Single X;
            public Single Y;
        }

        #endregion
    }
}
