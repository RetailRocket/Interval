namespace Interval
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public class IntervalComparer<TPoint>
        : IComparer<Interval<TPoint>>
    {
        private readonly IComparer<TPoint> pointComparer;

        public IntervalComparer(
            IComparer<TPoint> pointComparer)
        {
            this.pointComparer = pointComparer;
        }

        public int Compare(
            Interval<TPoint> left,
            Interval<TPoint> right)
        {
            var lowerBoundComparer = new LowerBoundComparer<TPoint>(
                pointComparer: this.pointComparer);

            var lowerBoundComparisonResult = lowerBoundComparer.Compare(
                left: left.LowerBound,
                right: right.LowerBound);

            if (lowerBoundComparisonResult != 0)
            {
                return lowerBoundComparisonResult;
            }

            var upperBoundComparer = new UpperBoundComparer<TPoint>(
                pointComparer: this.pointComparer);

            return upperBoundComparer.Compare(
                left: left.UpperBound,
                right: right.UpperBound);
        }
    }
}