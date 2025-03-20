using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectLib
{
    public class WeatherManager
    {

        private readonly string _apiKey = "94e6e26f2a7da7aa738469cd6838c23c";
        private readonly HttpClient _httpClient = new();

        public async Task<WeatherData> GetWeatherAsync(string cityName)
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}&units=metric&lang=ru";

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                _ = response.EnsureSuccessStatusCode(); // Выбрасывает исключение при ошибке HTTP

                string json = await response.Content.ReadAsStringAsync();

                // Десериализация с учетом регистра свойств
                JsonSerializerOptions options = new()
                {
                    PropertyNameCaseInsensitive = true
                };

                WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(json, options);
                return weatherData;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Ошибка подключения: " + ex.Message);
            }
            catch (JsonException ex)
            {
                throw new Exception("Ошибка парсинга JSON: " + ex.Message);
            }
        }

        public static async Task DisplayWeather(string city)
        {
            try
            {
                WeatherManager service = new();
                WeatherData data = await service.GetWeatherAsync(city);

                Console.WriteLine($"Погода в {data.Name}:");
                Console.WriteLine($"Температура: {data.Main.Temp}°C");
                Console.WriteLine($"Влажность: {data.Main.Humidity}%");

                if (data.Weather?.Count > 0)
                {
                    Console.WriteLine($"Описание: {data.Weather[0].Description}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

    }


}
