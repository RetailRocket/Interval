namespace Interval.IntervalBound.UpperBound
{
    using System;
    using System.Collections.Generic;

    public interface IUpperBound<TPoint>
    {
        int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer);
    }
}