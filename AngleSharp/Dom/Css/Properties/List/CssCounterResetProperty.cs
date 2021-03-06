﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/counter-reset
    /// </summary>
    sealed class CssCounterResetProperty : CssCounterProperty, ICssCounterResetProperty
    {
        #region Fields

        internal static readonly IValueConverter<KeyValuePair<String, Int32>[]> Converter = Converters.WithOrder(
            Converters.WithOrder(
                Converters.IdentifierConverter.Required(),
                Converters.IntegerConverter.Option(0)).To(
            m => new KeyValuePair<String, Int32>(m.Item1, m.Item2)));

        #endregion

        #region ctor

        internal CssCounterResetProperty(CssStyleDeclaration rule)
            : base(PropertyNames.CounterReset, rule)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(ICssValue value)
        {
            return Converter.TryConvert(value, SetCounters);
        }

        #endregion
    }
}
