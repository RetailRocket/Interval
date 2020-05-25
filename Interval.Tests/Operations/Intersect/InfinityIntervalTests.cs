namespace Interval.Tests.Operations.Intersect
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Interval.Operations;
    using Xunit;
    using IntervalFactory = Interval.IntervalFactory;

    public class InfinityIntervalTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(-100, -10)]
        [InlineData(10, 100)]
        public void IntersectWithClosedIntervalIsClosedInterval(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var infinityInterval = IntervalFactory.BuildInfinityInterval<int>();

            var result = infinityInterval.Intersect(
                rightInterval: IntervalFactory.BuildClosedInterval(
                    lowerBoundaryPoint: lowerBoundaryPoint,
                    upperBoundaryPoint: upperBoundaryPoint,
                    comparer: Comparer<int>.Default),
                comparer: Comparer<int>.Default);

            Assert.IsType<Interval<int>>(result);
            Assert.IsType<ClosedLowerBound<int>>(((Interval<int>)result).LowerBound);
            Assert.IsType<ClosedUpperBound<int>>(((Interval<int>)result).UpperBound);
        }

        [Theory]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(-100, -10)]
        [InlineData(10, 100)]
        public void IntersectWithOpenIntervalIsOpenInterval(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var infinityInterval = IntervalFactory.BuildInfinityInterval<int>();

            var result = infinityInterval.Intersect(
                rightInterval: IntervalFactory.BuildOpenInterval(
                    lowerBoundaryPoint: lowerBoundaryPoint,
                    upperBoundaryPoint: upperBoundaryPoint,
                    comparer: Comparer<int>.Default),
                comparer: Comparer<int>.Default);

            Assert.IsType<Interval<int>>(result);
            Assert.IsType<OpenLowerBound<int>>(((Interval<int>)result).LowerBound);
            Assert.IsType<OpenUpperBound<int>>(((Interval<int>)result).UpperBound);
        }
    }
}