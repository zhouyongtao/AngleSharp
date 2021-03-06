﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/table-layout
    /// </summary>
    sealed class CssTableLayoutProperty : CssProperty, ICssTableLayoutProperty
    {
        #region Fields

        internal static readonly IValueConverter<Boolean> Converter = Converters.Toggle(Keywords.Fixed, Keywords.Auto);
        internal static readonly Boolean Default = false;
        Boolean _fixed;

        #endregion

        #region ctor

        internal CssTableLayoutProperty(CssStyleDeclaration rule)
            : base(PropertyNames.TableLayout, rule)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets if table and column widths are set by the widths of table and
        /// col elements or by the width of the first row of cells. Cells in
        /// subsequent rows do not affect column widths. Otherwise an automatic
        /// table layout algorithm is commonly used by most browsers for table
        /// layout. The width of the table and its cells depends on the content
        /// thereof.
        /// </summary>
        public Boolean IsFixed
        {
            get { return _fixed; }
        }

        #endregion

        #region Methods

        public void SetFixed(Boolean @fixed)
        {
            _fixed = @fixed;
        }

        internal override void Reset()
        {
            _fixed = Default;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(ICssValue value)
        {
            return Converter.TryConvert(value, SetFixed);
        }

        #endregion
    }
}
