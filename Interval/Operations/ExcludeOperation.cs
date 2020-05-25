namespace Interval.Operations
{
    using System.Collections.Generic;
    using System.Linq;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public static class ExcludeOperation
    {
        public static List<Interval<TPoint>> Exclude<TPoint>(
            this Interval<TPoint> interval,
            HashSet<TPoint> pointSet,
            IComparer<TPoint> comparer)
            where TPoint : notnull
        {
            var orderedExclusions = pointSet.OrderBy(
                    key => key,
                    comparer: comparer)
                .Where(
                    p => interval.Contains(
                        point: p,
                        comparer: comparer));

            ILowerBound<TPoint> lowerBound = interval.LowerBound;
            var upperBound = interval.UpperBound;

            var intervalList = new List<IInterval<TPoint>>();

            foreach (var exclude in orderedExclusions)
            {
                intervalList.Add(IntervalFactory.Build(
                    lowerBound: lowerBound,
                    upperBound: new OpenUpperBound<TPoint>(
                        point: exclude),
                    comparer: comparer));

                lowerBound = new OpenLowerBound<TPoint>(
                    point: exclude);
            }

            intervalList.Add(IntervalFactory.Build(
                lowerBound: lowerBound,
                upperBound: upperBound,
                comparer: Comparer<TPoint>.Default));

            return intervalList
                .OfType<Interval<TPoint>>()
                .ToList();
        }

        public static List<Interval<TPoint>> Exclude<TPoint>(
            this IInterval<TPoint> interval,
            HashSet<TPoint> pointSet,
            IComparer<TPoint> comparer)
            where TPoint : notnull => interval switch
        {
            Interval<TPoint> i => i.Exclude(pointSet, comparer),
            _ => new List<Interval<TPoint>>()
        };
    }
}