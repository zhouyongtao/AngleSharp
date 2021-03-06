﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/position
    /// </summary>
    sealed class CssPositionProperty : CssProperty, ICssPositionProperty
    {
        #region Fields

        internal static readonly PositionMode Default = PositionMode.Static;
        internal static readonly IValueConverter<PositionMode> Converter = Map.PositionModes.ToConverter();
        PositionMode _mode;

        #endregion

        #region ctor

        internal CssPositionProperty(CssStyleDeclaration rule)
            : base(PropertyNames.Position, rule)
        {
            Reset();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the currently selected position mode.
        /// </summary>
        public PositionMode State
        {
            get { return _mode; }
        }

        #endregion

        #region Methods

        public void SetState(PositionMode mode)
        {
            _mode = mode;
        }

        internal override void Reset()
        {
            _mode = Default;
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(ICssValue value)
        {
            return Converter.TryConvert(value, SetState);
        }

        #endregion
    }
}
