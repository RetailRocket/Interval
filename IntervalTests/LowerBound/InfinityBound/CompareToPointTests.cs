namespace IntervalTests.LowerBound.InfinityBound
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
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
            var infinityLowerBound = new InfinityLowerBound<int>();

            Assert.True(
                infinityLowerBound.CompareToPoint(
                    point: point,
                    comparer: Comparer<int>.Default) < 0);
        }
    }
}