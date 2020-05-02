namespace Interval.IntervalBound.LowerBound
{
    using System.Collections.Generic;

    public class OpenLowerBound<TPoint>
        : ILowerBound<TPoint>, IPointedBound<TPoint>
    {
        public OpenLowerBound(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            if (comparer.Compare(this.Point, point) < 0)
            {
                return -1;
            }

            return 1;
        }
    }
}