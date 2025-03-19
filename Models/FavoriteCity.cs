using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherDashboard.Models
{
    [Table("FavoriteCity")] // Setting table name
    public class FavoriteCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Temp { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Description { get; set; }
    }
}
