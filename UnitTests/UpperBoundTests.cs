using System;
using Xunit;

namespace UnitTests
{
    using System.Collections.Generic;
    using Interval.IntervalBound.UpperBound;

    public class UpperBoundTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(1000)]
        [InlineData(-1000)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void WhenClosedAndOpenEqualClosedIsBigger(
            int value)
        {
            var UpperBoundComparer = new UpperBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = UpperBoundComparer.Compare(
                left: new ClosedUpperBound<int>(value),
                right: new OpenUpperBound<int>(value));

            Assert.Equal(
                expected: 1,
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
            var UpperBoundComparer = new UpperBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = UpperBoundComparer.Compare(
                left: new ClosedUpperBound<int>(closedBorderValue),
                right: new OpenUpperBound<int>(openBorderValue));

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
            var UpperBoundComparer = new UpperBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = UpperBoundComparer.Compare(
                left: new ClosedUpperBound<int>(closedBorderValue),
                right: new OpenUpperBound<int>(openBorderValue));

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
            var UpperBoundComparer = new UpperBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = UpperBoundComparer.Compare(
                left: new ClosedUpperBound<int>(closedBorderValue),
                right: new OpenUpperBound<int>(openBorderValue));

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
            var UpperBoundComparer = new UpperBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = UpperBoundComparer.Compare(
                left: new ClosedUpperBound<int>(closedBorderValue),
                right: new OpenUpperBound<int>(openBorderValue));

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
        public void InfinityUpperBorderIsAlwaysBiggerToAnyOpenUpperBorder(
            int value)
        {
            var UpperBoundComparer = new UpperBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = UpperBoundComparer.Compare(
                left: new InfinityUpperBound<int>(),
                right: new OpenUpperBound<int>(value));

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
        public void InfinityUpperBorderIsAlwaysBiggerToAnyCloseUpperBorder(
            int value)
        {
            var UpperBoundComparer = new UpperBoundComparer<int>(
                pointComparer: Comparer<int>.Default);

            var comparisonsA = UpperBoundComparer.Compare(
                left: new InfinityUpperBound<int>(),
                right: new ClosedUpperBound<int>(value));

            Assert.Equal(
                expected: 1,
                comparisonsA);
        }
    }
}