namespace Interval
{
    using System.Collections.Generic;

    public readonly struct UpperBound<TPoint>
    {
        private UpperBound(
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

        public static UpperBound<TPoint> Opened(TPoint point)
        {
            return new UpperBound<TPoint>(
                isOpened: true,
                value: point,
                isInfinity: false);
        }

        public static UpperBound<TPoint> Closed(TPoint point)
        {
            return new UpperBound<TPoint>(
                isOpened: false,
                value: point,
                isInfinity: false);
        }

        public static UpperBound<TPoint> Infinity()
        {
            return new UpperBound<TPoint>(
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
                return 1;
            }

            if (!this.IsOpened)
            {
                return comparer.Compare(this.Value, point);
            }

            return comparer.Compare(this.Value, point) == 1 ? 1 : -1;
        }
    }
}