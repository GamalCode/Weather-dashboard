using Microsoft.EntityFrameworkCore;
using WeatherDashboard.Models;

public class AppDbContext : DbContext // DbContext used to make connection between Models and PostgreSQL
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSet represent collection of rows
    public DbSet<FavoriteCity> FavoriteCity { get; set; }
}