namespace Operations
{
    using System.Collections.Generic;
    using Interval;

    public static class ContainsPointOperation
    {
        public static bool Contains<TPoint>(
            this Interval<TPoint> interval,
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return interval.LowerBound
                       .CompareToPoint(
                           point: point,
                           comparer: comparer) <= 0 &&
                   interval.UpperBound
                       .CompareToPoint(
                           point: point,
                           comparer: comparer) >= 0;
        }
    }
}