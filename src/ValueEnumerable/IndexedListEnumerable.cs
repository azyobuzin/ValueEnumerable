using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ValueEnumerable
{
    partial class ValueEnumerableExtensions
    {
        public struct IndexedListEnumerable<T> : IReadOnlyList<ValueTuple<T, int>>
        {
            private readonly IReadOnlyList<T> _list;

            internal IndexedListEnumerable(IReadOnlyList<T> enumerable)
            {
                _list = enumerable;
            }

            public IndexedListEnumerator<T> GetEnumerator()
            {
                return new IndexedListEnumerator<T>(_list);
            }

            [return: TupleElementNames(new[] { "item", "index" })]
            IEnumerator<ValueTuple<T, int>> IEnumerable<ValueTuple<T, int>>.GetEnumerator() => this.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            public int Count => _list.Count;

            [TupleElementNames(new[] { "item", "index" })]
            public ValueTuple<T, int> this[int index]
            {
                [return: TupleElementNames(new[] { "item", "index" })]
                get
                {
                    return ValueTuple.Create(_list[index], index);
                }
            }
        }

        public struct IndexedListEnumerator<T> : IEnumerator<ValueTuple<T, int>>
        {
            private readonly IReadOnlyList<T> _list;
            private int _index;

            internal IndexedListEnumerator(IReadOnlyList<T> list)
            {
                _list = list;
                _index = -1;
            }

            [TupleElementNames(new[] { "item", "index" })]
            public ValueTuple<T, int> Current
            {
                [return: TupleElementNames(new[] { "item", "index" })]
                get
                {
                    return ValueTuple.Create(_list[_index], _index);
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                return ++_index < _list.Count;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
