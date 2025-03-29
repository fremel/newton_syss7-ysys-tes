public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetWeather(string city)
    {
        var response = await _httpClient.GetAsync($"https://api.weather.com/weather/{city}");
        if (response.IsSuccessStatusCode)
        {
            var weatherData = await response.Content.ReadAsStringAsync();
            // Perform logic with the weather data (e.g., parse JSON, extract temperature)
            var temperature = ParseTemperature(weatherData);
            return $"{city} weather: Temperature is {temperature}°C";
        }
        else
        {
            return $"Failed to retrieve weather data for {city}";
        }
    }

    private int ParseTemperature(string weatherData)
    {
        var temperatureStartIndex = weatherData.IndexOf("\"temperature\":") + 14;
        var temperatureEndIndex = weatherData.IndexOf(",", temperatureStartIndex);
        var temperatureString = weatherData.Substring(temperatureStartIndex, temperatureEndIndex - temperatureStartIndex);
        return Convert.ToInt32(temperatureString);
    }
}
