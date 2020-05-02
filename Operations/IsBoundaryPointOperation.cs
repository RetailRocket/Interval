namespace Operations
{
    using System.Collections.Generic;
    using Interval.IntervalBound;

    public static class IsBoundaryPointOperation
    {
        public static bool HasBoundaryPont<TPoint>(
            this Interval.Interval<TPoint> interval,
            TPoint point,
            IComparer<TPoint> comparer)
        {
            if (interval.LowerBound is IPointedBound<TPoint> lowePointedBound
                && comparer.Compare(lowePointedBound.Point, point) == 0)
            {
                return true;
            }

            return interval.UpperBound is IPointedBound<TPoint> upperPointedBound
                   && comparer.Compare(upperPointedBound.Point, point) == 0;
        }
    }
}