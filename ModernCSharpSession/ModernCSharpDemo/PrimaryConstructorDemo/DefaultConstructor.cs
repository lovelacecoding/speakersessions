using PrimaryConstructorDemo.Services;

namespace PrimaryConstructorDemo;

public class DefaultConstructor
{
    private readonly IDateOnlyService _service;
    //private readonly DateOnlyService service;
    
    public DefaultConstructor(IDateOnlyService service)
    {
        _service = service;
        //this.service = service;
    }

    public DateOnly GiveMeTheDate()
    {
        return _service.Now();
    }
}