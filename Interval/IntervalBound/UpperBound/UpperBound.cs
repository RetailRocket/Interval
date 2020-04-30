namespace Interval.IntervalBound.UpperBound
{
    using System;
    using System.Collections.Generic;

    public abstract class UpperBound<TPoint>
    {
        public abstract int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer);

        public int Compare(
            UpperBound<TPoint> other,
            IComparer<TPoint> pointComparer)
        {
            switch (this)
            {
                case InfinityUpperBound<TPoint> _ when other is InfinityUpperBound<TPoint>:
                    return 0;
                case IPointedBound<TPoint> _ when other is InfinityUpperBound<TPoint>:
                    return -1;
                case InfinityUpperBound<TPoint> _ when other is IPointedBound<TPoint>:
                    return 1;
            }

            var thisPointedBorder = (IPointedBound<TPoint>)this;
            var otherPointedBorder = (IPointedBound<TPoint>)other;

            var resultOfComparisonsPointedBorders = pointComparer.Compare(thisPointedBorder.Point, otherPointedBorder.Point);
            if (resultOfComparisonsPointedBorders != 0) return resultOfComparisonsPointedBorders;

            switch (this)
            {
                case OpenUpperBound<TPoint> _ when other is OpenUpperBound<TPoint>:
                case ClosedUpperBound<TPoint> _ when other is ClosedUpperBound<TPoint>:
                    return 0;
                case ClosedUpperBound<TPoint> _ when other is OpenUpperBound<TPoint>:
                    return 1;
                case OpenUpperBound<TPoint> _ when other is ClosedUpperBound<TPoint>:
                    return -1;
            }

            throw new AggregateException("");
        }
    }
}