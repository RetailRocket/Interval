namespace UnitTests
{
    using System.Collections.Generic;
    using Interval;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Xunit;

    public class IntervalTestsAS
    {
        [Fact]
        public void UpperBoundDoNotCountedIfLowerBoundLess()
        {
            var intervalComparer = new IntervalComparer<int>(
                pointComparer: Comparer<int>.Default);

            var lowerInterval = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(10),
                upperBound: new ClosedUpperBound<int>(100));

            Assert.Equal(
                expected: -1,
                actual: intervalComparer.Compare(
                    left: lowerInterval,
                    right: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(11),
                        upperBound: new ClosedUpperBound<int>(50))));

            Assert.Equal(
                expected: -1,
                actual:  intervalComparer.Compare(
                    left: lowerInterval,
                    right: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(11),
                        upperBound: new ClosedUpperBound<int>(500))));

            Assert.Equal(
                expected: -1,
                actual:  intervalComparer.Compare(
                    left: lowerInterval,
                    right: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(11),
                        upperBound: new ClosedUpperBound<int>(12))));

            Assert.Equal(
                expected: 1,
                actual:  intervalComparer.Compare(
                    left: lowerInterval,
                    right: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(9),
                        upperBound: new ClosedUpperBound<int>(1200))));
        }
    }
}