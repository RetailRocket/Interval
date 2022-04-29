namespace Interval.IntervalBound.LowerBound
{
    using System.Collections.Generic;

    public class OpenLowerBound<TPoint> :
        ILowerPointedBound<TPoint>
        where TPoint : notnull
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

        public override int GetHashCode()
            => this.Point
                .GetHashCode();

        public override bool Equals(
            object obj)
        {
            return obj is OpenLowerBound<TPoint> key && this.Equals(key);
        }

        public bool Equals(
            OpenLowerBound<TPoint> other)
        {
            return other != null && EqualityComparer<TPoint>.Default.Equals(this.Point, other.Point);
        }
    }
}