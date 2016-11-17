using System.Linq;
using Xunit;

namespace ValueEnumerable.Tests
{
    public class IndexedEnumerableTest
    {
        [Fact]
        public void BasicTest()
        {
            foreach ((var x, var i) in Enumerable.Range(0, 10).Indexed())
            {
                Assert.Equal(x, i);
            }
        }
    }
}
