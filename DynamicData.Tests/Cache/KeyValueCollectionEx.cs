using System.Collections.Generic;
using System.Linq;
using DynamicData.Cache.Internal;

namespace DynamicData.Tests.Cache
{
    public static class KeyValueCollectionEx
    {
        public static IDictionary<TKey, IndexedItem<TObject, TKey>> Indexed<TObject, TKey>(this KeyValueCollection<TObject, TKey> source)
        {
            return source
                .Select((kv, idx) => new IndexedItem<TObject, TKey>(kv.Value, kv.Key, idx))
                .ToDictionary(i => i.Key);
        }
    }
}
