namespace Interval
{
    using System.Collections.Generic;

    public readonly struct LowerBound<TPoint>
    {
        private LowerBound(
            bool isOpened,
            TPoint value,
            bool isInfinity)
        {
            this.IsOpened = isOpened;
            this.Value = value;
            this.IsInfinity = isInfinity;
        }

        private bool IsOpened { get; }

        private TPoint Value { get; }

        private bool IsInfinity { get; }

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

        public static LowerBound<TPoint> Infinity()
        {
            return new LowerBound<TPoint>(
                isOpened: true,
                value: default!,
                isInfinity: true);
        }

        public int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            if (this.IsInfinity)
            {
                return -1;
            }

            if (!this.IsOpened)
            {
                return comparer.Compare(this.Value, point);
            }

            return comparer.Compare(this.Value, point) == -1 ? -1 : 1;
        }
    }
}