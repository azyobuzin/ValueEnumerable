using System;
using System.Collections.Generic;

namespace ValueEnumerable
{
    public static partial class ValueEnumerableExtensions
    {
        public static IndexedEnumerable<T> Indexed<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return new IndexedEnumerable<T>(source);
        }

        public static IndexedListEnumerable<T> Indexed<T>(this IReadOnlyList<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return new IndexedListEnumerable<T>(source);
        }
    }
}
