using System.Collections.Generic;
namespace WeatherPart_one
{
    internal interface INotify
    {
        int GetDayOfLeastTemperatureChange(IList<Weather> weatherData);
    }
}