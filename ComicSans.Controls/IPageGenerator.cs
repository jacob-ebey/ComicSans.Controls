using System;
using Xamarin.Forms;

namespace ComicSans.Controls
{
    /// <summary>
    /// Interface defining methods for determining if and how a new <see cref="Xamarin.Forms.Page"/> should be
    /// generated for the provided item.
    /// </summary>
    public interface IPageGenerator
    {
        /// <summary>
        /// Determines if the item should have a new page created for it.
        /// </summary>
        /// <returns><c>true</c>, if a page should be generated for the item, <c>false</c> otherwise.</returns>
        /// <param name="item">The item that is requesting to generate a new page.</param>
        bool ShouldGenerateFrom(object item);

        /// <summary>
        /// Determines if the binding context for the newly created <see cref="Xamarin.Forms.Page"/>.
        /// </summary>
        /// <returns><c>true</c>, if set binding context was shoulded, <c>false</c> otherwise.</returns>
        /// <param name="item">Item.</param>
        bool ShouldSetBindingContextOfNewPage(object item);

        /// <summary>
        /// Generate a new page for the specified item.
        /// </summary>
        /// <param name="item">The item that the page is to be generated for.</param>
        Page Generate(object item);
    }
}

