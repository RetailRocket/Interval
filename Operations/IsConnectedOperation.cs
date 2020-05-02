namespace Operations
{
    using System.Collections.Generic;
    using Operations.Comparers;

    public static class IsConnectedOperation
    {
        public static bool IsConnected<TPoint>(
            this Interval.Interval<TPoint> first,
            Interval.Interval<TPoint> second,
            IComparer<TPoint> pointComparer)
        {
            var lowerBoundComparer = new LowerBoundComparer<TPoint>(
                comparer: pointComparer);

            var upperBoundComparer = new UpperBoundComparer<TPoint>(
                pointComparer: pointComparer);

            return lowerBoundComparer.Compare(
                       left: first.LowerBound,
                       right: second.LowerBound) <= 0 &&
                   upperBoundComparer.Compare(
                       left: first.UpperBound,
                       right: second.UpperBound) >= 0;
        }
    }
}