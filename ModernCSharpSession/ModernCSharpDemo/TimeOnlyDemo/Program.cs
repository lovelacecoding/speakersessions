//TO-DO: set current time
//TO-DO: make custom time
//TO-DO: Compare current and custom
//TO-DO: Get hour, minute, second
//TO-DO: Math
//TO-DO: Format time string

TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
TimeOnly customTime = new TimeOnly(15,30,0);

if (currentTime > customTime)
{
    Console.WriteLine("current time is later");
}

else if (currentTime < customTime)
{
    Console.WriteLine("current time is earlier");
}

else
{
    Console.WriteLine("The time is the same");
}

Console.WriteLine(currentTime.ToString("h:mm:ss tt"));