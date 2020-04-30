namespace Interval.IntervalBound.LowerBound
{
    using System.Collections.Generic;

    public class ClosedLowerBound<TPoint>
        : LowerBound<TPoint>, IPointedBound<TPoint>
    {
        public ClosedLowerBound(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return comparer.Compare(this.Point, point);
        }
    }
}