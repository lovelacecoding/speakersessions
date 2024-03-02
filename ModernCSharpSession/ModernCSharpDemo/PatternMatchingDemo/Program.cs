using GridPoint = PatternMatchingDemo.GridPoint;

var point = new GridPoint(2, 3);

//Constant pattern
var message = "constant check";
if (message is 3)
{
    Console.WriteLine(message);
}

// Type pattern
if (point.X is int)
{
    Console.WriteLine($"Some value between 0-9");
}

//Var pattern
var mixedList = new object[] { "Hello", 123, true, 3.14 };
foreach (var item in mixedList)
{
    if (item is var x)
    {
        Console.WriteLine($"Type of x: {x.GetType()}");
    }
}

switch (point)
{
    // Positional patterns
    case (> 0, > 0):
        Console.WriteLine("Point is in the positive quadrant");
        break;
    case (0, 0):
        Console.WriteLine("Point is at the origin");
        break;
    default:
        Console.WriteLine("Point is in the negative quadrant");
        break;
}

string status = point switch
{
    { X: > 0, Y: > 0 } => "Point is in the positive quadrant",
    { X: 0, Y: 0 } => "Point is at the origin",
    _ => "Point is in the negative quadrant"
};

Console.WriteLine(status);



