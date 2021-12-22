using System;
using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public static class CollectionHelper
    {
        private static Random _random = new Random();

        /// Creates a subset of unique values from the supplied set. 
        public static IEnumerable<T> RandomizeSubset<T>(this IReadOnlyList<T> set, int amount)
        {
            if (set.Count <= amount)
            {
                return set;
            }

            var ret = new Dictionary<int, T>();

            while (ret.Count < amount)
            {
                var randIndex = _random.Next(set.Count);
                ret.TryAdd(randIndex, set[randIndex]);
            }

            return ret.Select(kv => kv.Value);
        }
    }
}
