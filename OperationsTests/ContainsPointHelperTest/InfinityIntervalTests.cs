namespace OperationsTests.ContainsPointHelperTest
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Operations;
    using Operations.Comparers;
    using Xunit;

    public class InfinityIntervalTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(9)]
        [InlineData(-9)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void Contains(
            int point)
        {
            var intervalComparer = new IntervalComparer<int>(
                comparer: Comparer<int>.Default);

            Assert.True(
                condition: new Interval.Interval<int>(
                        lowerBound: new InfinityLowerBound<int>(),
                        upperBound: new InfinityUpperBound<int>())
                    .Contains(
                        point: point,
                        comparer: Comparer<int>.Default));
        }
    }
}