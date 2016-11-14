using System;
using System.Collections;
using System.Collections.Generic;

namespace ValueEnumerable
{
    partial class Range
    {
        public struct RangeExclusive : IReadOnlyList<int>, IList<int>
        {
            public int Start { get; }
            public int End { get; }

            internal RangeExclusive(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }

            public RangeExclusiveEnumerator GetEnumerator()
            {
                return new RangeExclusiveEnumerator(this.Start, this.End);
            }

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => this.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            public int IndexOf(int item)
            {
                if (item < this.Start || item >= this.End)
                    return -1;

                return item - this.Start;
            }

            void IList<int>.Insert(int index, int item)
            {
                throw new NotSupportedException();
            }

            void IList<int>.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }

            void ICollection<int>.Add(int item)
            {
                throw new NotSupportedException();
            }

            void ICollection<int>.Clear()
            {
                throw new NotSupportedException();
            }

            public bool Contains(int item)
            {
                return item >= this.Start && item < this.End;
            }

            public void CopyTo(int[] array, int arrayIndex)
            {
                if (array == null) throw new ArgumentNullException(nameof(array));
                if (array.Length < this.End - this.Start + arrayIndex)
                    throw new ArgumentException("The array is not long enough.");

                for (var i = this.Start; i < this.End; i++)
                    array[arrayIndex + i] = this.Start + i;
            }

            bool ICollection<int>.Remove(int item)
            {
                throw new NotSupportedException();
            }

            public int Count => this.End - this.Start;

            bool ICollection<int>.IsReadOnly => true;

            public int this[int index]
            {
                get
                {
                    var i = this.Start + index;

                    if (i < this.Start || i >= this.End)
                        throw new ArgumentOutOfRangeException(nameof(index));

                    return i;
                }
                set
                {
                    throw new NotSupportedException();
                }
            }
        }

        public struct RangeExclusiveEnumerator : IEnumerator<int>
        {
            private readonly int _start;
            private readonly int _end;
            private int _current;

            internal RangeExclusiveEnumerator(int start, int end)
            {
                _start = start;
                _end = end;
                _current = unchecked(start - 1);
            }

            public int Current => _current;
            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                return unchecked(++_current) < _end;
            }

            public void Reset()
            {
                _current = unchecked(_start - 1);
            }

            public void Dispose() { }
        }
    }
}
