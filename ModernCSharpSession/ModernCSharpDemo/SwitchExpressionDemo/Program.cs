using SwitchExpressionDemo;

//TO-DO - Change switch case to switch expression

ToDo toDo = new ToDo("Create a demo for meeting", new DateOnly(2024,3,1) , PriorityLevel.High, true);
string solve = GetSolveTimeCase(toDo);

static string GetSolveTimeCase(ToDo toDo)
{
    switch (toDo.Level)
    {
        case PriorityLevel.High:
            return "Low Priority ToDo";
        case PriorityLevel.Medium:
            return "Medium Priority ToDo";
        case PriorityLevel.Low:
            return "High Priority ToDo";
        default:
            return "Unknown Priority";
    }
}

static string GetSolveTime(ToDo toDo)
{
    return toDo.Level switch
    {
        PriorityLevel.High => "Low Priority ToDo",
        PriorityLevel.Medium => "Medium Priority ToDo",
        PriorityLevel.Low => "High Priority ToDo",
        _ => "Unknown Priority"
    };

    static string GetSolveTime2(ToDo toDo)
    {
        return (toDo.Level, toDo.IsUrgent) switch
        {
            (PriorityLevel.High, true) => "Very Urgent High Priority ToDo",
            (PriorityLevel.High, false) => "Urgent High Priority ToDo",
            (PriorityLevel.Medium, true) => "Very Urgent Medium Priority ToDo",
            (PriorityLevel.Medium, false) => "Urgent Medium Priority ToDo",
            (PriorityLevel.Low, true) => "Very Urgent Low Priority ToDo",
            (PriorityLevel.Low, false) => "Urgent Low Priority ToDo",
            _ => "Unknown Priority"
        };
    }
}


