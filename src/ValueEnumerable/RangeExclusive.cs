using System.Collections;
using System.Collections.Generic;

namespace ValueEnumerable
{
    public struct RangeExclusive : IReadOnlyCollection<int>
    {
        public int Start { get; }
        public int End { get; }

        public RangeExclusive(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this.Start, this.End);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator() => this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public int Count => this.Start >= this.End ? 0 : checked(this.End - this.Start);

        public struct Enumerator : IEnumerator<int>
        {
            private readonly int _start;
            private readonly int _end;
            private int _current;

            internal Enumerator(int start, int end)
            {
                _start = start;
                _end = end;
                _current = start;
            }

            public int Current => _current - 1;
            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                if (_current < _end)
                {
                    _current++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _current = _start;
            }

            public void Dispose() { }
        }
    }
}
