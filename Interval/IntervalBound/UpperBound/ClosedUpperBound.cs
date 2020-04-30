namespace Interval.IntervalBound.UpperBound
{
    using System.Collections.Generic;

    public class ClosedUpperBound<TPoint>
        : UpperBound<TPoint>, IPointedBound<TPoint>
    {
        public ClosedUpperBound(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public override int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return comparer.Compare(this.Point, point);
        }
    }
}