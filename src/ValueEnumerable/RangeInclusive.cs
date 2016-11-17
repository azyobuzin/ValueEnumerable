using System;
using System.Collections;
using System.Collections.Generic;

namespace ValueEnumerable
{
    public struct RangeInclusive : IReadOnlyCollection<int>
    {
        public int Start { get; }
        public int End { get; }

        public RangeInclusive(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public static RangeInclusive CreateFromCount(int start, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), count, "count is less than 0.");
            long end = start + count - 1;
            if (end > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(count), count, "The value will overflow.");

            return new RangeInclusive(start, (int)end);
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this.Start, this.End);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator() => this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public int Count => this.Start > this.End ? 0 : checked(this.End - this.Start + 1);

        public struct Enumerator : IEnumerator<int>
        {
            private readonly int _end;
            private int _current;
            private bool _isFinished;

            internal Enumerator(int start, int end)
            {
                _end = end;
                _current = start - 1;
                _isFinished = start > end;
            }

            public int Current => _current;
            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                if (_isFinished) return false;
                _current++;
                _isFinished = _current >= _end;
                return true;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public void Dispose() { }
        }
    }
}
