namespace PrimaryConstructorDemo.Services;

public class DateOnlyService : IDateOnlyService
{
    public DateOnlyService()
    {
        
    }
    public DateOnly Now()
    {
        return new DateOnly();
    }
}