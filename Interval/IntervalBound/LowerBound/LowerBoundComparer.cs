namespace Interval.IntervalBound.LowerBound
{
    using System;
    using System.Collections.Generic;

    public class LowerBoundComparer<TPoint>
        : IComparer<ILowerBound<TPoint>>
    {
        private readonly IComparer<TPoint> pointComparer;

        public LowerBoundComparer(
            IComparer<TPoint> pointComparer)
        {
            this.pointComparer = pointComparer;
        }

        public int Compare(
            ILowerBound<TPoint> left,
            ILowerBound<TPoint> right)
        {
            switch (left)
            {
                case InfinityLowerBound<TPoint> _ when right is InfinityLowerBound<TPoint>:
                    return 0;
                case InfinityLowerBound<TPoint> _ when right is IPointedBound<TPoint>:
                    return -1;
                case IPointedBound<TPoint> _ when right is InfinityLowerBound<TPoint>:
                    return 1;
            }

            var leftPointedBorder = (IPointedBound<TPoint>)left;
            var rightPointedBorder = (IPointedBound<TPoint>)right;

            var resultOfComparisonsPointedBorders = this.pointComparer
                .Compare(
                    x: leftPointedBorder.Point,
                    y: rightPointedBorder.Point);

            if (resultOfComparisonsPointedBorders != 0)
            {
                return resultOfComparisonsPointedBorders;
            }

            switch (left)
            {
                case OpenLowerBound<TPoint> _ when right is OpenLowerBound<TPoint>:
                case ClosedLowerBound<TPoint> _ when right is ClosedLowerBound<TPoint>:
                    return 0;
                case ClosedLowerBound<TPoint> _ when right is OpenLowerBound<TPoint>:
                    return -1;
                case OpenLowerBound<TPoint> _ when right is ClosedLowerBound<TPoint>:
                    return 1;
            }

            throw new AggregateException(string.Empty);
        }
    }
}