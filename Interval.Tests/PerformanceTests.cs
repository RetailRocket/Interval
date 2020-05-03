#pragma warning disable
namespace Interval.Tests
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    public class PerformanceTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public PerformanceTests(
            ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact(Skip = "Just FYI")]
        public void SortLargeAmountOfIntervals()
        {
            var sw = Stopwatch.StartNew();
            var r = new Random();
            var intervals = Enumerable.Repeat(0, 10_000_000)
                .Select(_ => new Interval<int>(
                    LowerBound<int>.Opened(r.Next()),
                    UpperBound<int>.Closed(r.Next())))
                .ToList();

            var ordered = intervals.OrderBy(x => x).ToList();
            sw.Stop();
            this.testOutputHelper.WriteLine(sw.Elapsed.ToString());
        }
    }
}