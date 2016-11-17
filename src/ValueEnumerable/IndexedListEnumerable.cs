using System.Collections;
using System.Collections.Generic;

namespace ValueEnumerable
{
    partial class ValueEnumerableExtensions
    {
        public struct IndexedListEnumerable<T> : IReadOnlyList<(T item, int index)>
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

            IEnumerator<(T item, int index)> IEnumerable<(T item, int index)>.GetEnumerator() => this.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            public int Count => _list.Count;

            public (T item, int index) this[int index] => (_list[index], index);
        }

        public struct IndexedListEnumerator<T> : IEnumerator<(T item, int index)>
        {
            private readonly IReadOnlyList<T> _list;
            private int _index;

            internal IndexedListEnumerator(IReadOnlyList<T> list)
            {
                _list = list;
                _index = -1;
            }

            public (T item, int index) Current => (_list[_index], _index);

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
