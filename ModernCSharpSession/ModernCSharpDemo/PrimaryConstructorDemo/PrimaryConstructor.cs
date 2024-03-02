using PrimaryConstructorDemo.Services;

namespace PrimaryConstructorDemo;

public class PrimaryConstructor(IDateOnlyService service)
{
    public DateOnly GiveMeTheDate()
    {
        return service.Now();
    }
}