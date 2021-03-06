﻿namespace AngleSharp
{
    using AngleSharp.Dom;
    using AngleSharp.Extensions;
    using AngleSharp.Network;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A set of extensions for the browsing context.
    /// </summary>
    [DebuggerStepThrough]
    public static class ContextExtensions
    {
        #region Browsing Context

        /// <summary>
        /// Opens a new document without any content in the given context.
        /// </summary>
        /// <param name="context">The browsing context to use.</param>
        /// <returns>The new, yet empty, document.</returns>
        public static IDocument OpenNew(this IBrowsingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            return new Document(context);
        }

        /// <summary>
        /// Opens a new document asynchronously in the given context.
        /// </summary>
        /// <param name="context">The browsing context to use.</param>
        /// <param name="response">The response to examine.</param>
        /// <returns>The task that creates the document.</returns>
        public static Task<IDocument> OpenAsync(this IBrowsingContext context, IResponse response)
        {
            return context.OpenAsync(response, CancellationToken.None);
        }

        /// <summary>
        /// Opens a new document asynchronously in the given context.
        /// </summary>
        /// <param name="context">The browsing context to use.</param>
        /// <param name="response">The response to examine.</param>
        /// <param name="cancel">The cancellation token.</param>
        /// <returns>The task that creates the document.</returns>
        public static async Task<IDocument> OpenAsync(this IBrowsingContext context, IResponse response, CancellationToken cancel)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            else if (response == null)
                throw new ArgumentNullException("response");

            var doc = new Document(context);
            return await doc.LoadAsync(response, cancel).ConfigureAwait(false);
        }

        /// <summary>
        /// Opens a new document asynchronously in the given context.
        /// </summary>
        /// <param name="context">The browsing context to use.</param>
        /// <param name="url">The URL to load.</param>
        /// <returns>The task that creates the document.</returns>
        public static Task<IDocument> OpenAsync(this IBrowsingContext context, Url url)
        {
            return context.OpenAsync(url, CancellationToken.None);
        }

        /// <summary>
        /// Opens a new document asynchronously in the given context.
        /// </summary>
        /// <param name="context">The browsing context to use.</param>
        /// <param name="url">The URL to load.</param>
        /// <param name="cancel">The cancellation token.</param>
        /// <returns>The task that creates the document.</returns>
        public static async Task<IDocument> OpenAsync(this IBrowsingContext context, Url url, CancellationToken cancel)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            else if (url == null)
                throw new ArgumentNullException("url");

            var config = context.Configuration;
            var requester = config.GetRequester(url.Scheme);

            if (requester == null)
                return null;

            using (var response = await requester.LoadAsync(url, cancel).ConfigureAwait(false))
                return await context.OpenAsync(response, cancel).ConfigureAwait(false);
        }

        #endregion
    }
}
