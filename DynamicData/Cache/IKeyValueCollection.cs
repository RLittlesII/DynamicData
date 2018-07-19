using System;
using System.Collections.Generic;
// ReSharper disable once CheckNamespace
namespace DynamicData
{

    /// <summary>
    /// A sorted key value collection
    /// </summary>
    [Obsolete("The concrete implementation  is now used instead")]
    public interface IKeyValueCollection<TObject, TKey> : IEnumerable<KeyValuePair<TKey, TObject>>
    {
        /// <summary>
        /// Gets the comparer used to peform the sort
        /// </summary>
        /// <value>
        /// The comparer.
        /// </value>
        IComparer<KeyValuePair<TKey, TObject>> Comparer { get; }

        /// <summary>
        /// The count of items.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        int Count { get; }

        /// <summary>
        /// Gets the reason for a sort being applied.
        /// </summary>
        /// <value>
        /// The sort reason.
        /// </value>
        SortReason SortReason { get; }

        /// <summary>
        /// Gets the optimisations used to produce the sort
        /// </summary>
        /// <value>
        /// The optimisations.
        /// </value>
        SortOptimisations Optimisations { get; }

        /// <summary>
        /// Gets the element at the specified index in the read-only list.
        /// </summary>
        /// 
        /// <returns>
        /// The element at the specified index in the read-only list.
        /// </returns>
        /// <param name="index">The zero-based index of the element to get. </param>
        KeyValuePair<TKey, TObject> this[int index] { get; }
    }
}
