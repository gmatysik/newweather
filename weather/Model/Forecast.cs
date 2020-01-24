using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weather.Model
{
    public class Forecast
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string timezone { get; set; }
        public ForecastItem currently { get; set; }
        public HourlyForecast hourly { get; set; }

    }

    public class HourlyForecast
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public IList<ForecastItem> data { get; set; }
    }


    public class ForecastItem
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public string precipIntensity { get; set; }
        public string precipProbability { get; set; }
        public string temperature { get; set; }
        public string apparentTemperature { get; set; }
        public string dewPoint { get; set; }
        public string humidity { get; set; }
        public string pressure { get; set; }
        public string windSpeed { get; set; }
        public string windGust { get; set; }
        public string windBearing { get; set; }
        public string cloudCover { get; set; }
        public string uvIndex { get; set; }
        public string visibility { get; set; }
        public string ozone { get; set; }

        public string getFormattedTimeLocal()
        {
            return DateTimeOffset.FromUnixTimeSeconds(time).DateTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm");
        }

        public string getFormattedTimeGMT()
        {
            return DateTimeOffset.FromUnixTimeSeconds(time).DateTime.ToString("dd.MM.yyyy HH:mm");
        }

    }

}
