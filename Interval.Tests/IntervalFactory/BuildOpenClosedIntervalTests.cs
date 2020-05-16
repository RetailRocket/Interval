namespace Interval.Tests.IntervalFactory
{
    using System.Collections.Generic;
    using Xunit;
    using IntervalFactory = Interval.IntervalFactory;

    public class BuildOpenClosedIntervalTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(int.MaxValue, int.MinValue)]
        public void BuildEmptyInterval(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var interval = IntervalFactory.BuildOpenClosedInterval(
                lowerBoundaryPoint: lowerBoundaryPoint,
                upperBoundaryPoint: upperBoundaryPoint,
                comparer: Comparer<int>.Default);

            Assert.IsType<EmptyInterval<int>>(
                @object: interval);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(-1, 0)]
        public void BuildInterval(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var interval = IntervalFactory.BuildOpenClosedInterval(
                lowerBoundaryPoint: lowerBoundaryPoint,
                upperBoundaryPoint: upperBoundaryPoint,
                comparer: Comparer<int>.Default);

            Assert.IsType<Interval<int>>(
                @object: interval);
        }
    }
}