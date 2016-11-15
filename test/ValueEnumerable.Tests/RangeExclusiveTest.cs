using System.Linq;
using Xunit;

namespace ValueEnumerable.Tests
{
    public class RangeExclusiveTest
    {
        [Theory]
        [InlineData(int.MinValue, int.MinValue + 3)]
        [InlineData(int.MaxValue - 3, int.MaxValue)]
        public void BasicTest(int start, int end)
        {
            var count = end - start;
            var range = new RangeExclusive(start, end);
            Assert.Equal(count, range.Count);
            Assert.True(
                range.SequenceEqual(Enumerable.Range(start, end - start))
            );
        }

        [Fact]
        public void NoElement()
        {
            var range = new RangeExclusive(0, -1);
            Assert.Equal(0, range.Count);
            Assert.False(range.GetEnumerator().MoveNext());
        }
    }
}
