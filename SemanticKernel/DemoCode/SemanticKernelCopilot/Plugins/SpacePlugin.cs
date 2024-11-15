using System.ComponentModel;
using Microsoft.SemanticKernel;
using Oddity;
using Oddity.Models.Crew;
using Oddity.Models.Launches;

public class SpacePlugin
{
    private OddityCore _oddity;

    public SpacePlugin()
    {
        _oddity = new OddityCore();
    }

    [KernelFunction("get_latest_launch")]
    [Description("Gets the latest launch from Space X")]
    public async Task<string> GetLatestLaunch()
    {
        var launchInfo = _oddity.LaunchesEndpoint.GetLatest().ExecuteAsync().GetAwaiter().GetResult();
        return launchInfo.Name;
    }

    [KernelFunction("get_all_crew")]
    [Description("Gets the all crews from Space X")]
    public async Task<IEnumerable<string>> GetAllCrew()
    {
        var crewInfo = _oddity.CrewEndpoint.GetAll().ExecuteAsync().GetAwaiter().GetResult(); 
        var simpleCrew = crewInfo.Select(crew =>
        {
            return $"Name: {crew.Name}. Wiki: {crew.Wikipedia}. Agency: {crew.Agency}";
        });

        return simpleCrew;
    }
}


