namespace Interval.Tests.UpperBound.InfinityBound
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
        public void AnyPointIsLeftToBound(
            int point)
        {
            var infinityUpperBound = UpperBound<int>.Infinity();

            Assert.True(
                infinityUpperBound.CompareToPoint(
                    point: point,
                    comparer: Comparer<int>.Default) > 0);
        }
    }
}