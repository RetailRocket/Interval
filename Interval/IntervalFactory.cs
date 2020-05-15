namespace Interval
{
    using System;
    using System.Collections.Generic;
    using Interval.IntervalBound;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public static class IntervalFactory
    {
        public static IInterval<TPoint> Build<TPoint>(
            ILowerBound<TPoint> lowerBound,
            IUpperBound<TPoint> upperBound,
            IComparer<TPoint> comparer)
        {
            if (lowerBound is IPointedBound<TPoint> lb && upperBound is IPointedBound<TPoint> ub)
            {
                var pointComparisonResult = comparer.Compare(lb.Point, ub.Point);
                if (pointComparisonResult > 0)
                {
                    throw new ArgumentException();
                }

                if (pointComparisonResult == 0)
                {
                    if (lowerBound is OpenLowerBound<TPoint> && upperBound is OpenUpperBound<TPoint>)
                    {
                        throw new ArgumentException();
                    }

                    return new EmptyInterval<TPoint>();
                }
            }

            return new Interval<TPoint>(
                lowerBound: lowerBound,
                upperBound: upperBound);
        }

        public static IInterval<TPoint> BuildClosedInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
        {
            return new Interval<TPoint>(
                lowerBound: new ClosedLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static IInterval<TPoint> BuildOpenInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
        {
            return new Interval<TPoint>(
                lowerBound: new OpenLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static IInterval<TPoint> BuildOpenClosedInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
        {
            return new Interval<TPoint>(
                lowerBound: new OpenLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static IInterval<TPoint> BuildClosedOpenInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
        {
            return new Interval<TPoint>(
                lowerBound: new ClosedLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static Interval<TPoint> BuildInfinityInterval<TPoint>()
        {
            return new Interval<TPoint>(
                lowerBound: new InfinityLowerBound<TPoint>(),
                upperBound: new InfinityUpperBound<TPoint>());
        }

        public static Interval<TPoint> BuildInfinityOpenInterval<TPoint>(
            TPoint upperBoundaryPoint)
        {
            return new Interval<TPoint>(
                lowerBound: new InfinityLowerBound<TPoint>(),
                upperBound: new OpenUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static Interval<TPoint> BuildInfinityClosedInterval<TPoint>(
            TPoint upperBoundaryPoint)
        {
            return new Interval<TPoint>(
                lowerBound: new InfinityLowerBound<TPoint>(),
                upperBound: new ClosedUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static Interval<TPoint> BuildOpenInfinityInterval<TPoint>(
            TPoint lowerBoundaryPoint)
        {
            return new Interval<TPoint>(
                lowerBound: new OpenLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new InfinityUpperBound<TPoint>());
        }

        public static Interval<TPoint> BuildClosedInfinityInterval<TPoint>(
            TPoint lowerBoundaryPoint)
        {
            return new Interval<TPoint>(
                lowerBound: new ClosedLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new InfinityUpperBound<TPoint>());
        }
    }
}