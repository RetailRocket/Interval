namespace Interval.IntervalBound.UpperBound
{
    public interface IUpperPointedBound<TPoint>
        : IUpperBound<TPoint>
    {
        TPoint Point { get; }
    }
}