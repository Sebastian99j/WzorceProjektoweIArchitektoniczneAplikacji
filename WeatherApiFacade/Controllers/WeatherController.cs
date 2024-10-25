using Microsoft.AspNetCore.Mvc;

namespace WeatherApiFacade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherFacade _weatherFacade;

        public WeatherController(IConfiguration configuration)
        {
            string apiKey = configuration["WeatherApiKey"];
            _weatherFacade = new WeatherFacade(apiKey);
        }

        [HttpGet("temperature/{city}")]
        public async Task<IActionResult> GetTemperature(string city)
        {
            double? temperature = await _weatherFacade.GetCurrentTemperatureAsync(city);

            if (temperature.HasValue)
            {
                return Ok(new { City = city, Temperature = temperature.Value });
            }

            return NotFound(new { Message = "City not found or API error occurred." });
        }

        [HttpGet("weather/city/{city}")]
        public async Task<IActionResult> GetWeatherByCity(string city)
        {
            WeatherData weatherData = await _weatherFacade.GetWeatherByCityAsync(city);

            if (weatherData != null)
            {
                return Ok(weatherData);
            }

            return NotFound(new { Message = "City not found or API error occurred." });
        }

        [HttpGet("weather/coordinates")]
        public async Task<IActionResult> GetWeatherByCoordinates(double lat, double lon)
        {
            WeatherData weatherData = await _weatherFacade.GetWeatherByCoordinatesAsync(lat, lon);

            if (weatherData != null)
            {
                return Ok(weatherData);
            }

            return NotFound(new { Message = "Location not found or API error occurred." });
        }
    }
}
