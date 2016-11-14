using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ValueEnumerable
{
    partial class ValueEnumerableExtensions
    {
        public struct IndexedEnumerable<T> : IEnumerable<ValueTuple<T, int>>
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

            [return: TupleElementNames(new[] { "item", "index" })]
            IEnumerator<ValueTuple<T, int>> IEnumerable<ValueTuple<T, int>>.GetEnumerator() => this.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        public struct IndexedEnumerator<T> : IEnumerator<ValueTuple<T, int>>
        {
            private readonly IEnumerator<T> _enumerator;
            private int _index;

            internal IndexedEnumerator(IEnumerator<T> enumerator)
            {
                _enumerator = enumerator;
                _index = -1;
            }

            [TupleElementNames(new[] { "item", "index" })]
            public ValueTuple<T, int> Current
            {
                [return: TupleElementNames(new[] { "item", "index" })]
                get
                {
                    return ValueTuple.Create(_enumerator.Current, _index);
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }

            public bool MoveNext()
            {
                _index++;
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
