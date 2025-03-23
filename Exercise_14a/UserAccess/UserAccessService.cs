public class UserAccessService
{
    private readonly ITimeProvider _timeProvider;
    
    public UserAccessService(ITimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }
    
    public bool IsAccessAllowed()
    {
        var currentTime = _timeProvider.GetCurrentTime();
        return currentTime.Hour >= 9 && currentTime.Hour < 17;
    }
}