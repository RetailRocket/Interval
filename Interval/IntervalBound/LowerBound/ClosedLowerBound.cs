namespace Interval.IntervalBound.LowerBound
{
    using System.Collections.Generic;

    public class ClosedLowerBound<TPoint> :
        ILowerPointedBound<TPoint>
        where TPoint : notnull
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
            return EqualityComparer<TPoint>.Default.Equals(this.Point, other.Point);
        }
    }
}