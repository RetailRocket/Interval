namespace Interval.IntervalBound.UpperBound
{
    using System.Collections.Generic;

    public class OpenUpperBound<TPoint>
        : UpperBound<TPoint>, IPointedBound<TPoint>
    {
        public OpenUpperBound(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public override int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            if (comparer.Compare(this.Point, point) >= 0)
                return 1;

            return -1;
        }
    }
}