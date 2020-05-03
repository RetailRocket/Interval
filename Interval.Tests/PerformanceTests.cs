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
            var intervals = Enumerable.Repeat(0, 10_000_000)
                .Select(_ => new Interval<string>(
                    LowerBound<string>.Opened(Guid.NewGuid().ToString()),
                    UpperBound<string>.Closed(Guid.NewGuid().ToString())))
                .ToList();
            var genTime = sw.Elapsed;

            var ordered = intervals.OrderBy(x => x).ToList();
            sw.Stop();
            this.testOutputHelper.WriteLine("Gen time");
            this.testOutputHelper.WriteLine(genTime.ToString());
            this.testOutputHelper.WriteLine("Total time time");
            this.testOutputHelper.WriteLine(sw.Elapsed.ToString());
        }
    }
}