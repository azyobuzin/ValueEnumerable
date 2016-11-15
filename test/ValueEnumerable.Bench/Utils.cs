using System.Runtime.CompilerServices;

namespace ValueEnumerable.Bench
{
    internal static class Utils
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Ignore<T>(this T x) { }
    }
}
