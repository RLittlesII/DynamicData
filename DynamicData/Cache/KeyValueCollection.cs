using System.Collections.Generic;

namespace DynamicData.Cache.Internal
{
    /// <summary>
    /// A sorted key value collection
    /// </summary>
    public class KeyValueCollection<TObject, TKey> : List<KeyValuePair<TKey, TObject>>, IKeyValueCollection<TObject, TKey>
    {
        /// <inheritdoc />
        public KeyValueCollection(List<KeyValuePair<TKey, TObject>> items,
                                  IComparer<KeyValuePair<TKey, TObject>> comparer,
                                  SortReason sortReason,
                                  SortOptimisations optimisations)
            :base(items)
        {
            Comparer = comparer;
            SortReason = sortReason;
            Optimisations = optimisations;
        }

        /// <inheritdoc />
        public KeyValueCollection()
        {
            Optimisations = SortOptimisations.None;
            Comparer = new KeyValueComparer<TObject, TKey>();
        }

        /// <inheritdoc />
        public IComparer<KeyValuePair<TKey, TObject>> Comparer { get; }

        /// <inheritdoc />
        public SortReason SortReason { get; }

        /// <inheritdoc />
        public SortOptimisations Optimisations { get; }

    }
}
