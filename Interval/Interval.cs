namespace Interval
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public class Interval<TPoint>
    {
        public Interval(
            ILowerBound<TPoint> lowerBound,
            IUpperBound<TPoint> upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        public ILowerBound<TPoint> LowerBound { get; }

        public IUpperBound<TPoint> UpperBound { get; }

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
    }
}