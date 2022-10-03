using System.Collections.Generic;

namespace WeatherPart_one
{
    internal interface IReader
    {
        IList<Weather> GetWeatherData(string fileLocation);
    }
}