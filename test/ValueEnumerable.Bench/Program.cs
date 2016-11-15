using BenchmarkDotNet.Running;

namespace ValueEnumerable.Bench
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<RangeExclusiveBench>();
            BenchmarkRunner.Run<RangeInclusiveBench>();
        }
    }
}
