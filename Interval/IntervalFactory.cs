namespace Interval
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public static class IntervalFactory
    {
        public static IInterval<TPoint> Build<TPoint>(
            ILowerBound<TPoint> lowerBound,
            IUpperBound<TPoint> upperBound,
            IComparer<TPoint> comparer)
            where TPoint : notnull => (lowerBound, upperBound) switch
        {
            (ILowerPointedBound<TPoint> lpb, IUpperPointedBound<TPoint> upb) =>
            BuildPointedInterval(lpb, upb, comparer),
            _ => new Interval<TPoint>(lowerBound, upperBound)
        };

        public static IInterval<TPoint> BuildPointedInterval<TPoint>(
            ILowerPointedBound<TPoint> lpb,
            IUpperPointedBound<TPoint> upb,
            IComparer<TPoint> comparer)
            where TPoint : notnull => (lowerPointedBound: lpb, upperPointedBound: upb) switch
        {
            _ when comparer.Compare(lpb.Point, upb.Point) > 0 => new EmptyInterval<TPoint>(),
            (ClosedLowerBound<TPoint> _, ClosedUpperBound<TPoint> _) => new Interval<TPoint>(lpb, upb),
            _ when comparer.Compare(lpb.Point, upb.Point) == 0 => new EmptyInterval<TPoint>(),
            _ => new Interval<TPoint>(lpb, upb)
        };

        public static Interval<TPoint> BuildInfinityInterval<TPoint>()
            where TPoint : notnull
        {
            return new Interval<TPoint>(
                lowerBound: new InfinityLowerBound<TPoint>(),
                upperBound: new InfinityUpperBound<TPoint>());
        }

        public static Interval<TPoint> BuildInfinityOpenInterval<TPoint>(
            TPoint upperBoundaryPoint)
            where TPoint : notnull
        {
            return new Interval<TPoint>(
                lowerBound: new InfinityLowerBound<TPoint>(),
                upperBound: new OpenUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static Interval<TPoint> BuildInfinityClosedInterval<TPoint>(
            TPoint upperBoundaryPoint)
            where TPoint : notnull
        {
            return new Interval<TPoint>(
                lowerBound: new InfinityLowerBound<TPoint>(),
                upperBound: new ClosedUpperBound<TPoint>(upperBoundaryPoint));
        }

        public static Interval<TPoint> BuildOpenInfinityInterval<TPoint>(
            TPoint lowerBoundaryPoint)
            where TPoint : notnull
        {
            return new Interval<TPoint>(
                lowerBound: new OpenLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new InfinityUpperBound<TPoint>());
        }

        public static Interval<TPoint> BuildClosedInfinityInterval<TPoint>(
            TPoint lowerBoundaryPoint)
            where TPoint : notnull
        {
            return new Interval<TPoint>(
                lowerBound: new ClosedLowerBound<TPoint>(lowerBoundaryPoint),
                upperBound: new InfinityUpperBound<TPoint>());
        }

        public static IInterval<TPoint> BuildClosedInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
            where TPoint : notnull
        {
            return BuildPointedInterval(
                lpb: new ClosedLowerBound<TPoint>(lowerBoundaryPoint),
                upb: new ClosedUpperBound<TPoint>(upperBoundaryPoint),
                comparer: comparer);
        }

        public static IInterval<TPoint> BuildOpenInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
            where TPoint : notnull
        {
            return BuildPointedInterval(
                lpb: new OpenLowerBound<TPoint>(lowerBoundaryPoint),
                upb: new OpenUpperBound<TPoint>(upperBoundaryPoint),
                comparer: comparer);
        }

        public static IInterval<TPoint> BuildOpenClosedInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
            where TPoint : notnull
        {
            return BuildPointedInterval(
                lpb: new OpenLowerBound<TPoint>(lowerBoundaryPoint),
                upb: new ClosedUpperBound<TPoint>(upperBoundaryPoint),
                comparer: comparer);
        }

        public static IInterval<TPoint> BuildClosedOpenInterval<TPoint>(
            TPoint lowerBoundaryPoint,
            TPoint upperBoundaryPoint,
            IComparer<TPoint> comparer)
            where TPoint : notnull
        {
            return BuildPointedInterval(
                lpb: new ClosedLowerBound<TPoint>(lowerBoundaryPoint),
                upb: new OpenUpperBound<TPoint>(upperBoundaryPoint),
                comparer: comparer);
        }
    }
}