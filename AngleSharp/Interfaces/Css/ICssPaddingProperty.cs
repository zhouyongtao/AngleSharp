﻿namespace AngleSharp.Dom.Css
{
    /// <summary>
    /// Represents the CSS padding-right property.
    /// </summary>
    public interface ICssPaddingRightProperty : ICssProperty
    {
        /// <summary>
        /// Gets the padding relative to the width of the containing block or
        /// a fixed width.
        /// </summary>
        Length Right { get; }
    }

    /// <summary>
    /// Represents the CSS padding-top property.
    /// </summary>
    public interface ICssPaddingTopProperty : ICssProperty
    {
        /// <summary>
        /// Gets the padding relative to the width of the containing block or
        /// a fixed width.
        /// </summary>
        Length Top { get; }
    }

    /// <summary>
    /// Represents the CSS padding-bottom property.
    /// </summary>
    public interface ICssPaddingBottomProperty : ICssProperty
    {
        /// <summary>
        /// Gets the padding relative to the width of the containing block or
        /// a fixed width.
        /// </summary>
        Length Bottom { get; }
    }

    /// <summary>
    /// Represents the CSS padding-left property.
    /// </summary>
    public interface ICssPaddingLeftProperty : ICssProperty
    {
        /// <summary>
        /// Gets the padding relative to the width of the containing block or
        /// a fixed width.
        /// </summary>
        Length Left { get; }
    }

    /// <summary>
    /// Represents the CSS padding shorthand property.
    /// </summary>
    public interface ICssPaddingProperty : ICssProperty, ICssPaddingBottomProperty, ICssPaddingRightProperty, ICssPaddingTopProperty, ICssPaddingLeftProperty
    {
    }
}
