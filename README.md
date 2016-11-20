# ValueEnumerable
[![NuGet](https://img.shields.io/nuget/v/ValueEnumerable.svg)](https://www.nuget.org/packages/ValueEnumerable)

Now is the time to destroy `for` statement and use `foreach`.

# Example
## `Indexed` extension method
```csharp
using System;
using ValueEnumerable;

var array = new[] { 1, 1, 2, 3, 5 };

foreach ((int num, int index) in array.Indexed()) {
    Console.WriteLine($"{index}: {num}");
}
```

```
0: 1
1: 1
2: 2
3: 3
4: 5
```

## `RangeExclusive` struct
```csharp
using System;
using ValueEnumerable;

foreach (int i in new RangeExclusive(0, 10)) {
    Console.WriteLine(i);
}
```

```
0
1
2
3
4
5
6
7
8
9
```

## `RangeInclusive` struct
```csharp
using System;
using ValueEnumerable;

foreach (int i in new RangeInclusive(0, 10)) {
    Console.WriteLine(i);
}
```

```
0
1
2
3
4
5
6
7
8
9
10
```
