using System;
using Xunit;

namespace UnitTests
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;

    public class LowerBoundTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(1000)]
        [InlineData(-1000)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void WhenClosedAndOpenEqualClosedIsLess(
            int value)
        {
            var lowerBoundComparer = new LowerBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = lowerBoundComparer.Compare(
                left: new ClosedLowerBound<int>(value),
                right: new OpenLowerBound<int>(value));

            Assert.Equal(
                expected: -1,
                comparisonsA);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(-100, -99)]
        [InlineData(99, 100)]
        [InlineData(int.MaxValue - 1, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue + 1)]
        public void WhenClosedLessThanOpenThenClosedLess(
            int closedBorderValue,
            int openBorderValue)
        {
            var lowerBoundComparer = new LowerBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = lowerBoundComparer.Compare(
                left: new ClosedLowerBound<int>(closedBorderValue),
                right: new OpenLowerBound<int>(openBorderValue));

            Assert.Equal(
                expected: -1,
                comparisonsA);
        }


        [Theory]
        [InlineData(0, 1)]
        [InlineData(-100, -99)]
        [InlineData(99, 100)]
        [InlineData(int.MaxValue - 1, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue + 1)]
        public void WhenOpenLessThanCloseThenOpenLess(
            int closedBorderValue,
            int openBorderValue)
        {
            var lowerBoundComparer = new LowerBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = lowerBoundComparer.Compare(
                left: new ClosedLowerBound<int>(closedBorderValue),
                right: new OpenLowerBound<int>(openBorderValue));

            Assert.Equal(
                expected: -1,
                comparisonsA);
        }


        [Theory]
        [InlineData(1, 0)]
        [InlineData(100, 99)]
        [InlineData(int.MaxValue, int.MaxValue - 1)]
        [InlineData(int.MinValue + 1, int.MinValue)]
        public void WhenClosedBiggerThanOpenThenClosedBigger(
            int closedBorderValue,
            int openBorderValue)
        {
            var lowerBoundComparer = new LowerBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = lowerBoundComparer.Compare(
                left: new ClosedLowerBound<int>(closedBorderValue),
                right: new OpenLowerBound<int>(openBorderValue));

            Assert.Equal(
                expected: 1,
                comparisonsA);
        }


        [Theory]
        [InlineData(1, 0)]
        [InlineData(100, 99)]
        [InlineData(int.MaxValue, int.MaxValue - 1)]
        [InlineData(int.MinValue + 1, int.MinValue)]
        public void WhenOpenBiggerThanCloseThenClosedBigger(
            int closedBorderValue,
            int openBorderValue)
        {
            var lowerBoundComparer = new LowerBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = lowerBoundComparer.Compare(
                left: new ClosedLowerBound<int>(closedBorderValue),
                right: new OpenLowerBound<int>(openBorderValue));

            Assert.Equal(
                expected: 1,
                comparisonsA);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        [InlineData(-1000)]
        [InlineData(1000)]
        public void InfinityLowerBorderIsAlwaysLessToAnyOpenLowerBorder(
            int value)
        {
            var lowerBoundComparer = new LowerBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = lowerBoundComparer.Compare(
                left: new InfinityLowerBound<int>(),
                right: new OpenLowerBound<int>(value));

            Assert.Equal(
                expected: -1,
                comparisonsA);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        [InlineData(-1000)]
        [InlineData(1000)]
        public void InfinityLowerBorderIsAlwaysLessToAnyCloseLowerBorder(
            int value)
        {
            var lowerBoundComparer = new LowerBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = lowerBoundComparer.Compare(
                left: new InfinityLowerBound<int>(),
                right: new ClosedLowerBound<int>(value));

            Assert.Equal(
                expected: -1,
                comparisonsA);
        }
    }
}