namespace Interval
{
    using System;
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public static class IntervalFactory
    {
        public static IInterval<TPoint> BuildClosedInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
        {
            var pointComparisonResult = comparer.Compare(lowerBoundaryPoint, upperBoundaryPoint);
            if (pointComparisonResult > 0)
            {
                throw new ArgumentException();
            }

            return new Interval<TPoint>(
                lowerBound: new ClosedLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static IInterval<TPoint> BuildOpenInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
        {
            var pointComparisonResult = comparer.Compare(lowerBoundaryPoint, upperBoundaryPoint);
            if (pointComparisonResult >= 0)
            {
                throw new ArgumentException();
            }

            return new Interval<TPoint>(
                lowerBound: new OpenLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new OpenUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static IInterval<TPoint> BuildOpenCloseInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
        {
            var pointComparisonResult = comparer.Compare(lowerBoundaryPoint, upperBoundaryPoint);
            if (pointComparisonResult > 0)
            {
                throw new ArgumentException();
            }

            if (pointComparisonResult == 0)
            {
                return new EmptyInterval<TPoint>();
            }

            return new Interval<TPoint>(
                lowerBound: new OpenLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new ClosedUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static IInterval<TPoint> BuildCloseOpenInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
        {
            var pointComparisonResult = comparer.Compare(lowerBoundaryPoint, upperBoundaryPoint);
            if (pointComparisonResult > 0)
            {
                throw new ArgumentException();
            }

            if (pointComparisonResult == 0)
            {
                return new EmptyInterval<TPoint>();
            }

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