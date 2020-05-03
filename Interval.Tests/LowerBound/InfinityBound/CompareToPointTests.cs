namespace Interval.Tests.LowerBound.InfinityBound
{
    using System.Collections.Generic;
    using Xunit;

    public class CompareToPointTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void AnyPointIsRightToBound(
            int point)
        {
            var infinityLowerBound = LowerBound<int>.Infinity();

            Assert.True(
                infinityLowerBound.CompareTo(
                    other: point) < 0);
        }
    }
}