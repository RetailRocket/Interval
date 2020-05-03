namespace Interval.Tests.LowerBound.ClosedBound
{
    using System.Collections.Generic;
    using Xunit;

    public class CompareToPointTests
    {
        [Theory]
        [InlineData(0, -1)]
        [InlineData(-1, -2)]
        [InlineData(0, int.MinValue)]
        [InlineData(int.MaxValue, int.MaxValue - 1)]
        public void PointToTheLeftTest(
            int lowerBoundPoint,
            int point)
        {
            var closedLowerBound = UpperBound<int>.Closed(
                point: lowerBoundPoint);

            Assert.True(
                closedLowerBound.CompareToPoint(
                    point: point,
                    comparer: Comparer<int>.Default) > 0);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(-1, 0)]
        [InlineData(int.MinValue, int.MinValue + 1)]
        [InlineData(int.MaxValue - 1, int.MaxValue)]
        public void PointToTheRightTest(
            int lowerBoundPoint,
            int point)
        {
            var closedLowerBound = UpperBound<int>.Closed(
                point: lowerBoundPoint);

            Assert.True(
                closedLowerBound.CompareToPoint(
                    point: point,
                    comparer: Comparer<int>.Default) < 0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void PointOnBound(
            int point)
        {
            var closedLowerBound = UpperBound<int>.Closed(
                point: point);

            Assert.True(
                closedLowerBound.CompareToPoint(
                    point: point,
                    comparer: Comparer<int>.Default) == 0);
        }
    }
}