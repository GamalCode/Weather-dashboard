using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherDashboard.Models;

public class WeatherController : Controller
{
    private readonly IWeatherService _weatherService;
    private readonly AppDbContext _context;

    public WeatherController(IWeatherService weatherService, AppDbContext context)
    {
        _weatherService = weatherService;
        _context = context;
    }

    public async Task<IActionResult> Index(string city)
    {
        if (string.IsNullOrEmpty(city))
        {
            return View();
        }

        try
        {
            var weatherInformation = await _weatherService.GetWeatherAsync(city);
            return View(weatherInformation);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddToFavorites(string city)
    {
        if (string.IsNullOrEmpty(city))
        {
            return RedirectToAction("Index");
        }

        var weatherInformation = await _weatherService.GetWeatherAsync(city);

        // Removing favorite city
        var existingFavorite = await _context.FavoriteCity.FirstOrDefaultAsync();
        if (existingFavorite != null)
        {
            _context.FavoriteCity.Remove(existingFavorite);
        }

        // Adding new favorite city
        var favoriteCity = new FavoriteCity
        {
            Name = weatherInformation.Name,
            Temp = weatherInformation.Main.Temp,
            Humidity = weatherInformation.Main.Humidity,
            WindSpeed = weatherInformation.Wind.Speed,
            Description = weatherInformation.Weather.FirstOrDefault()?.Description
        };
        _context.FavoriteCity.Add(favoriteCity);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", new { city });
    }

    public async Task<IActionResult> FavoriteCity()
    {
        var favoriteCity = await _context.FavoriteCity.FirstOrDefaultAsync();
        return View(favoriteCity);
    }
}
