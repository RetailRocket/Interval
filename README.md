![.NET Core](https://github.com/RetailRocket/Interval/workflows/.NET%20Core/badge.svg)
[![NuGet version](https://img.shields.io/nuget/v/Interval.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/Interval/)

# Interval

Generic library of types to describe interval of any points that can be compared to eachother. The library is as small as possible to be useful. I've created it to use in my own implimentation of [Iterval Centered Tree](https://github.com/RetailRocket/CenteredIntervalTree). To do it I was need a couple of additional operation which I've implemented in external library of [Interval Operations](https://github.com/RetailRocket/Interval.Operations) on purpose to keep this library clear.

## Description ###

Interval<TPoint> with lower and upper bounds. Each of bound can be of three types: Open, Close and Infinity. It alows to create combinations of intervals:

#### Closed 
Both boundaries points are inculded to theinterval

![](readme/images/closed.png)

[a, b] = {x | a <= x <= b}

#### Open
Both boundaries points are not inculded to the interval

![](readme/images/open.png)

(a, b) = {x | a < x < b}

#### openClosed (a, b]
Lower boundary point is not included to the interval, upper bound is included to the interval

![](readme/images/openClosed.png)

(a, b] = {x | a < x <= b}

#### closedOpen [a, b)
Lower boundary point is included to the interval, upper bound is not

![](readme/images/closedOpen.png)

[a, b) = {x | a <= x < b}

#### infinityOpen 
Lower boundary is infinity and any point of the interval is more than it boundary, upper boundary point is not included to the interval

![](readme/images/infinityOpen.png)

[∞, a) = {x | ∞ < x < b}


#### infinityClosed [∞, a]
Lower boundary is infinity and any point of the interval is more than it boundary, upper boundary point is included to the interval

![](readme/images/infinityClosed.png)

[∞, a) = {x | ∞ < x <= b}

#### openInfinity
Lower boundary point is not included to the interval, upper bound is infinity and any point of interval is less that it boundary

![](readme/images/openInfinity.png)

(a, ∞] = {x | a < x < ∞}

#### closedInfinity 
Lower boundary point is included to the interval, upper bound is infinity and any point of interval is less that it boundary

![](readme/images/closedInfinity.png)

[a, ∞) = {x | a <= x < ∞}

Each boundary contains method ```CompareToPoint``` is allows to get position of point compare to boundary. For example point 0 with comparison to open lower bound of 0 will be less but for closed lower bound it will be equal. Infinity lower bound will be always less than any point but Infinity upper bound will be greater than any point.

## Usage ###

### Interval 

Interval type is generic type and can have boundaries point of any type, but for comparison operation you will need to have comparer class for point type

### Interval Boundaries

Interval type have two boundaries, each of them have three possible types. It enable to have up to nine different intervals.

```csharp
var closedInterval = new Interval<int>(
    lowerBound: ...,
    upperBound: ...
);
```

#### Closed Interval
```csharp
var closedInterval = new Interval<int>(
    lowerBound: new ClosedLowerBound<int>(0),
    upperBound: new ClosedUpperBound<int>(10));
```
#### Open Interval
```csharp
var closedInterval = new Interval.Interval<int>(
    lowerBound: new OpenLowerBound<int>(0),
    upperBound: new OpenUpperBound<int>(10));
```

#### Infinity Interval
```csharp
var closedInterval = new Interval<int>(
    lowerBound: new InfinityLowerBound<int>(),
    upperBound: new InfinityUpperBound<int>());
```

And you can combine bounds, for example

#### Open Closed Interval

```csharp
var openClosedInterval = new Interval<int>(
    lowerBound: new OpenLowerBound<int>(0),
    upperBound: new ClosedUpperBound<int>(10));
```

etc.


### Boundary Operation

Every boundary can be compared to point by ```CompareToPoint``` method. Methor returns -1 boundary at the left, 1 if the boundary at the right and 0 if point on the boundary.

```csharp
  new ClosedLowerBound<int>(10)
    .CompareToPoint(
        point: 10,
        comparer: Comparer<int>.Default); // > 0 - point is on the boundary
```

### Additional Operation

Additional operation you can find in library [Interval Operations](https://github.com/RetailRocket/Interval.Operations)
