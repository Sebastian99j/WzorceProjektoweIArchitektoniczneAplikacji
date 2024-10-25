using Newtonsoft.Json.Linq;

namespace WeatherApiFacade
{
    public class WeatherFacade
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public WeatherFacade(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        public async Task<double?> GetCurrentTemperatureAsync(string cityName)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}&units=metric";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject weatherData = JObject.Parse(jsonResponse);
                return weatherData["main"]?["temp"]?.Value<double>();
            }

            return null;
        }

        public async Task<WeatherData> GetWeatherByCityAsync(string cityName)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}&units=metric";
            return await GetWeatherDataAsync(url);
        }

        public async Task<WeatherData> GetWeatherByCoordinatesAsync(double lat, double lon)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={_apiKey}&units=metric";
            return await GetWeatherDataAsync(url);
        }

        private async Task<WeatherData> GetWeatherDataAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject weatherData = JObject.Parse(jsonResponse);

                return new WeatherData
                {
                    City = weatherData["name"]?.ToString(),
                    Temperature = weatherData["main"]?["temp"]?.Value<double>() ?? 0,
                    Humidity = weatherData["main"]?["humidity"]?.Value<int>() ?? 0,
                    WindSpeed = weatherData["wind"]?["speed"]?.Value<double>() ?? 0,
                    WeatherDescription = weatherData["weather"]?[0]?["description"]?.ToString()
                };
            }

            return null;
        }
    }
}
