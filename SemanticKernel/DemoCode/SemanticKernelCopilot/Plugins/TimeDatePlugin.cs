using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernelCopilot.Plugins;

public class TimeDatePlugin
{
    [KernelFunction("get_date")]
    [Description("gets date right now")]
    [return: Description("Returns date")]
    public DateOnly GetDate()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }
    
    [KernelFunction("get_time")]
    [Description("gets time right now")]
    public TimeOnly GetTime()
    {
        return TimeOnly.FromDateTime(DateTime.Now);
    }
}