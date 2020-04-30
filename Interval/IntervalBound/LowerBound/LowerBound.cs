namespace Interval.IntervalBound.LowerBound
{
    using System;
    using System.Collections.Generic;

    public interface LowerBound<TPoint>
    {
        int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer);
    }
}