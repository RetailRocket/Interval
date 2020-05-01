namespace Interval.IntervalBound.LowerBound
{
    using System.Collections.Generic;

    public class InfinityLowerBound<TPoint>
        : ILowerBound<TPoint>
    {
        public int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return -1;
        }
    }
}