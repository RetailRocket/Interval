namespace OperationsTests.ComparersTests.IntervalComparer
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Operations.Comparers;
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
            var intervalComparer = new IntervalComparer<int>(
                comparer: Comparer<int>.Default);

            var intervalA = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundaryPoint));

            var intervalB = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundaryPoint));

            Assert.Equal(
                expected: 0,
                actual: intervalComparer.Compare(
                    left: intervalA,
                    right: intervalB));
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
            var intervalComparer = new IntervalComparer<int>(
                comparer: Comparer<int>.Default);

            var intervalA = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<int>(upperBoundaryPoint));

            var intervalB = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<int>(upperBoundaryPoint));

            Assert.Equal(
                expected: 0,
                actual: intervalComparer.Compare(
                    left: intervalA,
                    right: intervalB));
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
            var intervalComparer = new IntervalComparer<int>(
                comparer: Comparer<int>.Default);

            var intervalA = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<int>(upperBoundaryPoint));

            var intervalB = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<int>(upperBoundaryPoint));

            Assert.Equal(
                expected: 0,
                actual: intervalComparer.Compare(
                    left: intervalA,
                    right: intervalB));

            var intervalС = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundaryPoint));

            var intervalВ = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundaryPoint));

            Assert.Equal(
                expected: 0,
                actual: intervalComparer.Compare(
                    left: intervalA,
                    right: intervalB));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(100)]
        [InlineData(0)]
        public void MixedInfinityBoundaryWithOpenClosedBoundaryIntervalCanBeEqual(
            int boundaryPoint)
        {
            var intervalComparer = new IntervalComparer<int>(
                comparer: Comparer<int>.Default);

            var intervalA = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new OpenUpperBound<int>(boundaryPoint));

            var intervalB = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new OpenUpperBound<int>(boundaryPoint));

            Assert.Equal(
                expected: 0,
                actual: intervalComparer.Compare(
                    left: intervalA,
                    right: intervalB));

            var intervalС = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(boundaryPoint),
                upperBound: new InfinityUpperBound<int>());

            var intervalВ = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(boundaryPoint),
                upperBound: new InfinityUpperBound<int>());

            Assert.Equal(
                expected: 0,
                actual: intervalComparer.Compare(
                    left: intervalA,
                    right: intervalB));
        }

        [Fact]
        public void InfinityBoundariesIntervalAreEqual()
        {
            var intervalComparer = new IntervalComparer<int>(
                comparer: Comparer<int>.Default);

            var intervalA = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new InfinityUpperBound<int>());

            var intervalB = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new InfinityUpperBound<int>());

            Assert.Equal(
                expected: 0,
                actual: intervalComparer.Compare(
                    left: intervalA,
                    right: intervalB));
        }
    }
}