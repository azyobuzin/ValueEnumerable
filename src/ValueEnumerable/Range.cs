using System;
using System.Collections.Generic;

namespace ValueEnumerable
{
    public static partial class Range
    {
        public static RangeExclusive CreateExclusive(int start, int end)
        {
            if (start > end) throw new ArgumentException("start is greater than end.");
            return new RangeExclusive(start, end);
        }

        // RangeInclusive Create(int start, int count)
        // RangeInclusive CreateInclusive(int start, int end)
    }
}
