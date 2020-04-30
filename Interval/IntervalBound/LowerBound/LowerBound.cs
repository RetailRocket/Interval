namespace Interval.IntervalBound.LowerBound
{
    using System;
    using System.Collections.Generic;

    public abstract class LowerBound<TPoint>
    {
        public abstract int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer);

        public int Compare(
            LowerBound<TPoint> other,
            IComparer<TPoint> pointComparer)
        {
            switch (this)
            {
                case InfinityLowerBound<TPoint> _ when other is InfinityLowerBound<TPoint>:
                    return 0;
                case InfinityLowerBound<TPoint> _ when other is IPointedBound<TPoint>:
                    return -1;
                case IPointedBound<TPoint> _ when other is InfinityLowerBound<TPoint>:
                    return 1;
            }

            var leftPointedBorder = (IPointedBound<TPoint>)this;
            var rightPointedBorder = (IPointedBound<TPoint>)other;

            var resultOfComparisonsPointedBorders = pointComparer.Compare(leftPointedBorder.Point, rightPointedBorder.Point);
            if (resultOfComparisonsPointedBorders != 0) return resultOfComparisonsPointedBorders;


            switch (this)
            {
                case OpenLowerBound<TPoint> _ when other is OpenLowerBound<TPoint>:
                case ClosedLowerBound<TPoint> _ when other is ClosedLowerBound<TPoint>:
                    return 0;
                case ClosedLowerBound<TPoint> _ when other is OpenLowerBound<TPoint>:
                    return -1;
                case OpenLowerBound<TPoint> _ when other is ClosedLowerBound<TPoint>:
                    return 1;
            }

            throw new AggregateException("");
        }
    }
}