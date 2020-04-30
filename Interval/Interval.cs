namespace Interval
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public class Interval<TPoint>
    {
        public LowerBound<TPoint> LowerBound { get; }

        public UpperBound<TPoint> UpperBound { get; }

        public Interval(
            LowerBound<TPoint> lowerBound,
            UpperBound<TPoint> upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        public bool Contains(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return this.LowerBound.CompareToPoint(
                       point: point,
                       comparer: comparer) >= 0 &&
                   this.UpperBound.CompareToPoint(
                       point: point,
                       comparer: comparer) <= 0;
        }

        public int Compare(
            Interval<TPoint> other,
            IComparer<TPoint> pointComparer)
        {
            var lowerBoundComparisonResult = this.LowerBound
                .Compare(
                    other: other.LowerBound,
                    pointComparer: pointComparer);

            if (lowerBoundComparisonResult != 0)
                return lowerBoundComparisonResult;

            return this.UpperBound
                .Compare(
                    other: other.UpperBound,
                    pointComparer: pointComparer);
        }
    }
}