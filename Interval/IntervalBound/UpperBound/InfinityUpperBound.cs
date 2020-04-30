namespace Interval.IntervalBound.UpperBound
{
    using System.Collections.Generic;

    public class InfinityUpperBound<TPoint>
        : UpperBound<TPoint>
    {
        public int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return 1;
        }
    }
}