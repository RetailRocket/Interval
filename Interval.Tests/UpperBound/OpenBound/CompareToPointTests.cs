namespace Interval.Tests.UpperBound.OpenBound
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
            var closedUpperBound = UpperBound<int>.Opened(
                point: lowerBoundPoint);

            Assert.True(
                closedUpperBound.CompareTo(
                    other: point) > 0);
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
            var closedUpperBound = UpperBound<int>.Opened(
                point: lowerBoundPoint);

            Assert.True(
                closedUpperBound.CompareTo(
                    other: point) < 0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void PointOnBoundIsLeftToBound(
            int point)
        {
            var closedUpperBound = UpperBound<int>.Opened(
                point: point);

            Assert.True(
                closedUpperBound.CompareTo(
                    other: point) < 0);
        }
    }
}