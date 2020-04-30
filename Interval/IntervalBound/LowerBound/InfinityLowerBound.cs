namespace Interval.IntervalBound.LowerBound
{
    using System.Collections.Generic;

    public class InfinityLowerBound<TPoint>
        : LowerBound<TPoint>
    {
        public override int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return -1;
        }
    }
}