namespace OperationsTests.ContainsPointHelperTest
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Operations;
    using Operations.Comparers;
    using Xunit;

    public class OpenIntervalTests
    {
        [Theory]
        [InlineData(0, 10, 1)]
        [InlineData(0, 10, 9)]
        [InlineData(-10, 10, -9)]
        [InlineData(-10, 10, 9)]
        [InlineData(-10, 10, 0)]
        public void Contains(
            int lowerBoundaryPoint,
            int upperBoundaryPoint,
            int point)
        {
            var intervalComparer = new IntervalComparer<int>(
                comparer: Comparer<int>.Default);

            Assert.True(
                condition: new Interval.Interval<int>(
                        lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                        upperBound: new OpenUpperBound<int>(upperBoundaryPoint))
                    .Contains(
                        point: point,
                        comparer: Comparer<int>.Default));
        }

        [Theory]
        [InlineData(0, 10, 0)]
        [InlineData(0, 10, 10)]
        [InlineData(-10, 10, -10)]
        [InlineData(-10, 10, 10)]
        [InlineData(-10, 10, -11)]
        [InlineData(-10, 10, 11)]
        public void DoesNotContains(
            int lowerBoundaryPoint,
            int upperBoundaryPoint,
            int point)
        {
            var intervalComparer = new IntervalComparer<int>(
                comparer: Comparer<int>.Default);

            Assert.False(
                condition: new Interval.Interval<int>(
                        lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                        upperBound: new OpenUpperBound<int>(upperBoundaryPoint))
                    .Contains(
                        point: point,
                        comparer: Comparer<int>.Default));
        }
    }
}