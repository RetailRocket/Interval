namespace UnitTests
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Xunit;

    public class IntervalTestsAS
    {
        [Fact]
        public void UpperBoundDoNotCountedIfLowerBoundLess()
        {
            var lowerInterval = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(10),
                upperBound: new ClosedUpperBound<int>(100));

            Assert.Equal(
                expected: -1,
                actual: lowerInterval.Compare(
                    other: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(11),
                        upperBound: new ClosedUpperBound<int>(50)),
                    pointComparer: Comparer<int>.Default));

            Assert.Equal(
                expected: -1,
                actual: lowerInterval.Compare(
                    other: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(11),
                        upperBound: new ClosedUpperBound<int>(500)),
                    pointComparer: Comparer<int>.Default));

            Assert.Equal(
                expected: -1,
                actual: lowerInterval.Compare(
                    other: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(11),
                        upperBound: new ClosedUpperBound<int>(12)),
                    pointComparer: Comparer<int>.Default));

            Assert.Equal(
                expected: 1,
                actual: lowerInterval.Compare(
                    other: new Interval.Interval<int>(
                        lowerBound: new ClosedLowerBound<int>(9),
                        upperBound: new ClosedUpperBound<int>(1200)),
                    pointComparer: Comparer<int>.Default));
        }
    }
}