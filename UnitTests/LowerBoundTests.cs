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
            var comparisonsA = new ClosedLowerBound<int>(value).Compare(
                new OpenLowerBound<int>(value),
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
        public void WhenClosedLessThanOpenThenClosedLess(
            int closedBorderValue,
            int openBorderValue)
        {
            var comparisonsA = new ClosedLowerBound<int>(closedBorderValue).Compare(
                new OpenLowerBound<int>(openBorderValue),
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
            var comparisonsA = new ClosedLowerBound<int>(closedBorderValue).Compare(
                new OpenLowerBound<int>(openBorderValue),
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
            var comparisonsA = new ClosedLowerBound<int>(closedBorderValue).Compare(
                new OpenLowerBound<int>(openBorderValue),
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
            var comparisonsA = new ClosedLowerBound<int>(closedBorderValue).Compare(
                new OpenLowerBound<int>(openBorderValue),
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
        public void InfinityIsAlwaysLessToAnyOpenBorder(
            int value)
        {
            var comparisonsA = new InfinityLowerBound<int>().Compare(
                new OpenLowerBound<int>(value),
                pointComparer: Comparer<int>.Default);

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
        public void InfinityIsAlwaysLessToAnyClosedBorder(
            int value)
        {
            var comparisonsA = new InfinityLowerBound<int>().Compare(
                new ClosedLowerBound<int>(value),
                pointComparer: Comparer<int>.Default);

            Assert.Equal(
                expected: -1,
                comparisonsA);
        }
    }
}