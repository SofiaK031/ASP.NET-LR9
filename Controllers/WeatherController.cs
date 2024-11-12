using LR9.Services;
using Microsoft.AspNetCore.Mvc;

namespace LR9.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // Метод для відображення погоди у місті
        public async Task<IActionResult> Index(string city = "Kyiv")
        {
            if (string.IsNullOrEmpty(city))
            {
                return View("Error", "City name cannot be empty.");
            }

            var weatherData = await _weatherService.GetWeatherAsync(city);

            if (weatherData == null)
            {
                return View("Error", "Weather data could not be retrieved.");
            }

            ViewBag.City = city;

            return View(weatherData);
        }
    }
}