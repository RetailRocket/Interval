namespace UnitTests.IntervalTests.Comparison
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Xunit;

    public class EqualityTests
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(-10, -10)]
        [InlineData(-10, 10)]
        [InlineData(100, 100)]
        [InlineData(0, 10)]
        public void ClosedBoundariesIntervalAreEqual(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var intervalA = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundaryPoint));

            var intervalB = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundaryPoint));

            intervalA.Compare(
                other: intervalB,
                pointComparer: Comparer<int>.Default);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(-10, -10)]
        [InlineData(-10, 10)]
        [InlineData(100, 100)]
        [InlineData(0, 10)]
        public void OpenBoundariesIntervalAreEqual(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var intervalA = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<int>(upperBoundaryPoint));

            var intervalB = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<int>(upperBoundaryPoint));

            intervalA.Compare(
                other: intervalB,
                pointComparer: Comparer<int>.Default);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(-10, -10)]
        [InlineData(-10, 10)]
        [InlineData(100, 100)]
        [InlineData(0, 10)]
        public void MixedOpenClosedBoundariesIntervalCanBeEqual(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var intervalA = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<int>(upperBoundaryPoint));

            var intervalB = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<int>(upperBoundaryPoint));

            intervalA.Compare(
                other: intervalB,
                pointComparer: Comparer<int>.Default);

            var intervalС = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundaryPoint));

            var intervalВ = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundaryPoint));

            intervalA.Compare(
                other: intervalB,
                pointComparer: Comparer<int>.Default);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(100)]
        [InlineData(0)]
        public void MixedInfinityBoundaryWithOpenClosedBoundaryIntervalCanBeEqual(
            int boundaryPoint)
        {
            var intervalA = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new OpenUpperBound<int>(boundaryPoint));

            var intervalB = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new OpenUpperBound<int>(boundaryPoint));

            intervalA.Compare(
                other: intervalB,
                pointComparer: Comparer<int>.Default);

            var intervalС = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(boundaryPoint),
                upperBound: new InfinityUpperBound<int>());

            var intervalВ = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(boundaryPoint),
                upperBound: new InfinityUpperBound<int>());

            intervalA.Compare(
                other: intervalB,
                pointComparer: Comparer<int>.Default);
        }

        [Fact]
        public void InfinityBoundariesIntervalAreEqual()
        {
            var intervalA = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new InfinityUpperBound<int>());

            var intervalB = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new InfinityUpperBound<int>());

            Assert.Equal(
                expected: 0,
                actual: intervalA.Compare(
                    other: intervalB,
                    pointComparer: Comparer<int>.Default));
        }
    }
}