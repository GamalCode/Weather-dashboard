using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherDashboard.Models;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "35fc80ec94885e020a356fd131a1a306";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherInformation> GetWeatherAsync(string city)
    {
        var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";

        try
        {
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API Response:");
            Console.WriteLine(json);

            var weatherInformation = JsonSerializer.Deserialize<WeatherInformation>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (weatherInformation == null)
            {
                throw new Exception("Failed to deserialize weather data.");
            }

            Console.WriteLine("Deserialized Weather Information:");
            Console.WriteLine($"City: {weatherInformation.Name}");
            Console.WriteLine($"Temperature: {weatherInformation.Main?.Temp}");
            Console.WriteLine($"Humidity: {weatherInformation.Main?.Humidity}");
            Console.WriteLine($"Wind Speed: {weatherInformation.Wind?.Speed}");
            Console.WriteLine($"Description: {weatherInformation.Weather?.FirstOrDefault()?.Description}");

            return weatherInformation;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP Request Error: {ex.Message}");
            throw new Exception("Failed to fetch weather data.", ex);
        }
    }

}