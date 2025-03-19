using System.Threading.Tasks;
using WeatherDashboard.Models;

public interface IWeatherService
{
    Task<WeatherInformation> GetWeatherAsync(string city);
}