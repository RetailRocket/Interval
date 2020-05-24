namespace Interval.IntervalBound.UpperBound
{
    public interface IUpperPointedBound<TPoint>
        : IUpperBound<TPoint>
        where TPoint : notnull
    {
        TPoint Point { get; }
    }
}