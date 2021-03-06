﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Css.Values;
    using AngleSharp.Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/text-shadow
    /// </summary>
    sealed class CssTextShadowProperty : CssProperty, ICssTextShadowProperty
    {
        #region Fields

        internal static readonly Shadow[] Default = new Shadow[0];
        internal static readonly IValueConverter<Shadow[]> Converter = Converters.ShadowConverter.FromList().Or(Keywords.None, Default);
        readonly List<Shadow> _shadows;

        #endregion

        #region ctor

        internal CssTextShadowProperty(CssStyleDeclaration rule)
            : base(PropertyNames.TextShadow, rule, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
            _shadows = new List<Shadow>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an enumeration over all the set shadows.
        /// </summary>
        public IEnumerable<Shadow> Shadows
        {
            get { return _shadows; }
        }

        #endregion

        #region Methods

        public void SetShadows(IEnumerable<Shadow> shadows)
        {
            _shadows.Clear();
            _shadows.AddRange(shadows);
        }

        internal override void Reset()
        {
            _shadows.Clear();
            _shadows.AddRange(Default);
        }

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(ICssValue value)
        {
            return Converter.TryConvert(value, SetShadows);
        }

        #endregion
    }
}
