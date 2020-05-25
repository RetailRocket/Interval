namespace Interval.Tests.Operations.Exclude
{
    using System.Collections.Generic;
    using Interval.Operations;
    using Xunit;
    using IntervalFactory = Interval.IntervalFactory;

    public class ClosedIntervalTests
    {
        [Fact]
        public void Test()
        {
            var interval = IntervalFactory.BuildClosedInterval(
                lowerBoundaryPoint: -10,
                upperBoundaryPoint: 10,
                comparer: Comparer<int>.Default);

            var intervalList = interval.Exclude(
                pointSet: new HashSet<int> { 5 },
                comparer: Comparer<int>.Default);

            Assert.Equal(
                expected: 2,
                actual: intervalList.Count);
        }
    }
}