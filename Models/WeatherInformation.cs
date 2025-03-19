using System.Collections.Generic;

namespace WeatherDashboard.Models
{
    public class WeatherInformation
    {
        public string Name { get; set; }
        public WeatherTemperature Main { get; set; }
        public List<WeatherDescription> Weather { get; set; }
        public WeatherWind Wind { get; set; }
    }
}