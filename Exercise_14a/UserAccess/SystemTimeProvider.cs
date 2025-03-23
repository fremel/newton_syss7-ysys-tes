public class SystemTimeProvider : ITimeProvider
{
    public DateTime GetCurrentTime()
    {
        DateTime dateTime = DateTime.Now;
        Console.WriteLine($"Current time: {dateTime}");
        return dateTime;
    }
}