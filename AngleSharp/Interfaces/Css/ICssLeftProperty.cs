﻿namespace AngleSharp.Dom.Css
{
    /// <summary>
    /// Represents the CSS left property.
    /// </summary>
    public interface ICssLeftProperty : ICssProperty
    {
        /// <summary>
        /// Gets the position if a fixed position has been set.
        /// </summary>
        Length? Left { get; }
    }
}
