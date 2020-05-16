namespace Interval
{
    using System.Collections.Generic;
    using Interval.IntervalBound;

    public static class IntersectOperation
    {
        public static IInterval<TPoint> Intersect<TPoint>(
            this Interval<TPoint> leftInterval,
            Interval<TPoint> rightInterval,
            IComparer<TPoint> comparer)
        {
            var lowerBoundComparer = new LowerBoundComparer<TPoint>(comparer);
            var upperBoundComparer = new UpperBoundComparer<TPoint>(comparer);

            return IntervalFactory.Build<TPoint>(
                lowerBound: lowerBoundComparer.Compare(leftInterval.LowerBound, rightInterval.LowerBound) >= 0
                    ? leftInterval.LowerBound
                    : rightInterval.LowerBound,
                upperBound: upperBoundComparer.Compare(leftInterval.UpperBound, rightInterval.UpperBound) <= 0
                    ? leftInterval.UpperBound
                    : rightInterval.UpperBound,
                comparer: comparer);
        }

        public static IInterval<TPoint> Intersect<TPoint>(
            this IInterval<TPoint> leftInterval,
            IInterval<TPoint> rightInterval,
            IComparer<TPoint> comparer) => (leftInterval, rightInterval) switch
        {
            (Interval<TPoint> leftNotEmptyInterval, Interval<TPoint> rightNotEmptyInterval) => leftNotEmptyInterval
                .Intersect(rightNotEmptyInterval, comparer),
            _ => new EmptyInterval<TPoint>()
        };
    }
}