using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ValueEnumerable.Bench
{
    public class RangeExclusiveBench
    {
        private const int Start = 0;
        private const int Count = 1000;

        [Benchmark]
        public static void RangeExclusive()
        {
            foreach (var i in new RangeExclusive(Start, Count))
                i.Ignore();
        }

        [Benchmark]
        public static void For()
        {
            for (var i = Start; i < Count; i++)
                i.Ignore();
        }

        [Benchmark]
        public static void EnumerableRange()
        {
            foreach (var i in Enumerable.Range(Start, Count))
                i.Ignore();
        }
    }
}
