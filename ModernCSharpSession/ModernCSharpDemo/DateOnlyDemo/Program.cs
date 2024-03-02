//TO-DO: set currentDate
//TO-DO: make customDate
//TO-DO: Compare current and custom
//TO-DO: Get year, month, day
//TO-DO: Add
//TO-DO: Format date string
//TO-DO: Change calendar type (hebrew)

using System.Globalization;

DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
DateOnly customDate = new DateOnly(2024, 2, 29);

// if (currentDate > customDate)
// {
//     Console.WriteLine("current date is later");
// }
//
// else if (currentDate < customDate)
// {
//     Console.WriteLine("current date is earlier");
// }
//
// else
// {
//     Console.WriteLine("The date is the same");
// }

Console.WriteLine(currentDate);
var theDate = new DateOnly(5776, 2, 8, new HebrewCalendar());

Console.WriteLine(theDate);