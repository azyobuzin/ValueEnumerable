using System.Collections;
using System.Collections.Generic;

namespace ValueEnumerable
{
    partial class ValueEnumerableExtensions
    {
        public struct IndexedEnumerable<T> : IEnumerable<(T item, int index)>
        {
            private readonly IEnumerable<T> _enumerable;

            internal IndexedEnumerable(IEnumerable<T> enumerable)
            {
                _enumerable = enumerable;
            }

            public IndexedEnumerator<T> GetEnumerator()
            {
                return new IndexedEnumerator<T>(_enumerable.GetEnumerator());
            }

            IEnumerator<(T item, int index)> IEnumerable<(T item, int index)>.GetEnumerator() => this.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        public struct IndexedEnumerator<T> : IEnumerator<(T item, int index)>
        {
            private readonly IEnumerator<T> _enumerator;
            private int _index;

            internal IndexedEnumerator(IEnumerator<T> enumerator)
            {
                _enumerator = enumerator;
                _index = -1;
            }

            public (T item, int index) Current => (_enumerator.Current, _index);

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                checked { _index++; }
                return _enumerator.MoveNext();
            }

            public void Reset()
            {
                _enumerator.Reset();
                _index = -1;
            }
        }
    }
}
