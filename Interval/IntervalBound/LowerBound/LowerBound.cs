namespace Interval.IntervalBound.LowerBound
{
    using System;
    using System.Collections.Generic;

    public struct LowerBound<TPoint> where TPoint : struct, IComparable<TPoint>
    {
        private bool IsOpened;
        private TPoint? value;
        private bool IsInfinity;

        private LowerBound(
            bool isOpened,
            TPoint? value,
            bool isInfinity)
        {
            this.IsOpened = isOpened;
            this.value = value;
            this.IsInfinity = isInfinity;
        }

        public static LowerBound<TPoint> Opened(TPoint point)
        {
            return new LowerBound<TPoint>(
                isOpened: true,
                value: point,
                isInfinity: false);
        }

        public static LowerBound<TPoint> Closed(TPoint point)
        {
            return new LowerBound<TPoint>(
                isOpened: false,
                value: point,
                isInfinity: false);
        }

        public static LowerBound<TPoint> Infinity(TPoint point)
        {
            return new LowerBound<TPoint>(
                isOpened: true,
                value: null,
                isInfinity: true);
        }
    }
}