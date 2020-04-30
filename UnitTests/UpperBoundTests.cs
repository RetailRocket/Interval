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
            var comparisonsA = new ClosedUpperBound<int>(value).Compare(
                new OpenUpperBound<int>(value),
                pointComparer: Comparer<int>.Default);

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
            var comparisonsA = new ClosedUpperBound<int>(closedBorderValue).Compare(
                new OpenUpperBound<int>(openBorderValue),
                pointComparer: Comparer<int>.Default);

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
            var comparisonsA = new ClosedUpperBound<int>(closedBorderValue).Compare(
                new OpenUpperBound<int>(openBorderValue),
                pointComparer: Comparer<int>.Default);

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
            var comparisonsA = new ClosedUpperBound<int>(closedBorderValue).Compare(
                new OpenUpperBound<int>(openBorderValue),
                pointComparer: Comparer<int>.Default);

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
            var comparisonsA = new ClosedUpperBound<int>(closedBorderValue).Compare(
                new OpenUpperBound<int>(openBorderValue),
                pointComparer: Comparer<int>.Default);

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
        public void InfinityIsAlwaysBiggerToAnyOpenBorder(
            int value)
        {
            var comparisonsA = new InfinityUpperBound<int>().Compare(
                new OpenUpperBound<int>(value),
                pointComparer: Comparer<int>.Default);

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
        public void InfinityIsAlwaysBiggerToAnyClosedBorder(
            int value)
        {
            var comparisonsA = new InfinityUpperBound<int>().Compare(
                new ClosedUpperBound<int>(value),
                pointComparer: Comparer<int>.Default);

            Assert.Equal(
                expected: 1,
                comparisonsA);
        }
    }
}