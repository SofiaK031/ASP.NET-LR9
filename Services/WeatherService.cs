using LR9.Models;
using Newtonsoft.Json;

namespace LR9.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiKey = configuration["WeatherApi:APIKey"];
        }
        public async Task<WeatherModel> GetWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response JSON: {responseContent}");

                // Десеріалізація JSON у модель WeatherModel
                var weatherData = JsonConvert.DeserializeObject<WeatherModel>(responseContent);

                if (weatherData?.WeatherMain == null)
                {
                    Console.WriteLine("WeatherMain is null");
                }
                else
                {
                    Console.WriteLine($"Temperature: {weatherData.WeatherMain.Temp}\nHumidity: {weatherData.WeatherMain.Humidity}");
                }

                return weatherData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching weather data.", ex);
            }
        }
    }
}