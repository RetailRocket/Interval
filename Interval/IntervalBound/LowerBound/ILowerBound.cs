namespace Interval.IntervalBound.LowerBound
{
    using System.Collections.Generic;

    public interface ILowerBound<TPoint>
        where TPoint : notnull
    {
        int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer);
    }
}