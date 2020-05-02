namespace Operations.Comparers
{
    using System.Collections.Generic;
    using Interval;

    public class IntervalComparer<TPoint>
        : IComparer<Interval<TPoint>>
    {
        private readonly IComparer<TPoint> comparer;

        public IntervalComparer(
            IComparer<TPoint> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(
            Interval<TPoint> left,
            Interval<TPoint> right)
        {
            var lowerBoundComparer = new LowerBoundComparer<TPoint>(
                comparer: this.comparer);

            var lowerBoundComparisonResult = lowerBoundComparer.Compare(
                left: left.LowerBound,
                right: right.LowerBound);

            if (lowerBoundComparisonResult != 0)
            {
                return lowerBoundComparisonResult;
            }

            var upperBoundComparer = new UpperBoundComparer<TPoint>(
                pointComparer: this.comparer);

            return upperBoundComparer.Compare(
                left: left.UpperBound,
                right: right.UpperBound);
        }
    }
}