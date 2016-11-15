using System.Linq;
using Xunit;

namespace ValueEnumerable.Tests
{
    public class RangeInclusiveTest
    {
        [Theory]
        [InlineData(int.MinValue, int.MinValue + 3)]
        [InlineData(int.MaxValue - 3, int.MaxValue)]
        [InlineData(0, 0)]
        public void BasicTest(int start, int end)
        {
            var count = end - start + 1;
            var range = new RangeInclusive(start, end);
            Assert.Equal(count, range.Count);
            Assert.True(
                range.SequenceEqual(Enumerable.Range(start, count))
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
