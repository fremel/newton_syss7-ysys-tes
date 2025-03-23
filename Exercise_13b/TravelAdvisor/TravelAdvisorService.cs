public class TravelAdvisorService
{
    private readonly ICountryInfoService _countryInfoService;
    private readonly INotificationService _notificationService;

    public TravelAdvisorService(ICountryInfoService countryInfoService, INotificationService notificationService)
    {
        _countryInfoService = countryInfoService;
        _notificationService = notificationService;
    }

    public void ProvideTravelAdvice(string userId, string countryCode)
    {
        throw new NotImplementedException();
    }
}
