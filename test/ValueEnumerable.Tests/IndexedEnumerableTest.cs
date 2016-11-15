using System.Linq;
using Xunit;

namespace ValueEnumerable.Tests
{
    public class IndexedEnumerableTest
    {
        [Fact]
        public void BasicTest()
        {
            foreach (var x in Enumerable.Range(0, 10).Indexed())
            {
                Assert.Equal(x.Item2, x.Item1);
            }
        }

        // TODO: Test the compatibility with C# 7 Tuple syntax
    }
}
