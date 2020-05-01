namespace UnitTests.IntervalTests.Comparison
{
    using System.Collections.Generic;
    using Interval;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Xunit;

    public class UpperBoundDoNotCountedIfLowerBoundLessTests
    {
        [Theory]
        [InlineData(10, 100, 11, 50, -1)]
        [InlineData(11, 100, 10, 500, 1)]
        [InlineData(10, 100, 11, 500, -1)]
        [InlineData(10, 100, 11, 12, -1)]
        [InlineData(-10, -100, -9, -50, -1)]
        [InlineData(-9, -100, -10, -50, 1)]
        public void ClosedIntervalTest(
            int leftLowerValue,
            int leftUpperValue,
            int rightLowerValue,
            int rightUpperValue,
            int result)
        {
            var intervalComparer = new IntervalComparer<int>(
                pointComparer: Comparer<int>.Default);

            Assert.Equal(
                expected: result,
                actual: intervalComparer.Compare(
                    left: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(leftLowerValue),
                        upperBound: new ClosedUpperBound<int>(leftUpperValue)),
                    right: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(rightLowerValue),
                        upperBound: new ClosedUpperBound<int>(rightUpperValue))));
        }

        [Theory]
        [InlineData(10, 100, 11, 50, -1)]
        [InlineData(11, 100, 10, 500, 1)]
        [InlineData(10, 100, 11, 500, -1)]
        [InlineData(10, 100, 11, 12, -1)]
        [InlineData(-10, -100, -9, -50, -1)]
        [InlineData(-9, -100, -10, -50, 1)]
        public void OpenIntervalTest(
            int leftLowerValue,
            int leftUpperValue,
            int rightLowerValue,
            int rightUpperValue,
            int result)
        {
            var intervalComparer = new IntervalComparer<int>(
                pointComparer: Comparer<int>.Default);

            Assert.Equal(
                expected: result,
                actual: intervalComparer.Compare(
                    left: new Interval.Interval<int>(
                        lowerBound: new OpenLowerBound<int>(leftLowerValue),
                        upperBound: new OpenUpperBound<int>(leftUpperValue)),
                    right: new Interval.Interval<int>(
                        lowerBound: new OpenLowerBound<int>(rightLowerValue),
                        upperBound: new OpenUpperBound<int>(rightUpperValue))));
        }

        [Theory]
        [InlineData(11, 50)]
        [InlineData(11, 500)]
        [InlineData(11, 12)]
        [InlineData(-10, -9)]
        public void InfinityToOpenIntervalTest(
            int leftUpperValue,
            int rightUpperValue)
        {
            var intervalComparer = new IntervalComparer<int>(
                pointComparer: Comparer<int>.Default);

            Assert.Equal(
                expected: -1,
                actual: intervalComparer.Compare(
                    left: new Interval.Interval<int>(
                        lowerBound: new InfinityLowerBound<int>(),
                        upperBound: new OpenUpperBound<int>(leftUpperValue)),
                    right: new Interval.Interval<int>(
                        lowerBound: new InfinityLowerBound<int>(),
                        upperBound: new OpenUpperBound<int>(rightUpperValue))));
        }

        [Theory]
        [InlineData(11, 50)]
        [InlineData(11, 500)]
        [InlineData(11, 12)]
        [InlineData(-10, -9)]
        public void InfinityToCloseIntervalTest(
            int leftUpperValue,
            int rightUpperValue)
        {
            var intervalComparer = new IntervalComparer<int>(
                pointComparer: Comparer<int>.Default);

            Assert.Equal(
                expected: -1,
                actual: intervalComparer.Compare(
                    left: new Interval.Interval<int>(
                        lowerBound: new InfinityLowerBound<int>(),
                        upperBound: new ClosedUpperBound<int>(leftUpperValue)),
                    right: new Interval.Interval<int>(
                        lowerBound: new InfinityLowerBound<int>(),
                        upperBound: new ClosedUpperBound<int>(rightUpperValue))));
        }
    }
}