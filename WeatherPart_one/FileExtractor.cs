using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPart_one
{
    internal class FileExtractor 
    {
        private readonly System.IO.Abstractions.IFileSystem _fileSystem;

        public FileExtractor(System.IO.Abstractions.IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IList<Weather> GetWeatherData(string fileLocation)
        {
            // Contract checks.
            if (string.IsNullOrWhiteSpace(fileLocation)) throw new ArgumentNullException(nameof(fileLocation), "The file location can not be null.");

            var file = _fileSystem.File.ReadAllLines(fileLocation);
            if (!file.Any() || !file.First().Contains(AppConstants.WeatherHeader)) throw new System.IO.InvalidDataException("Invalid File Data.  No rows found.");

            var results = new List<Weather>();

            foreach (var item in file)
            {
                // Need to use the config to extract out the items...
                if (!item.Equals(AppConstants.WeatherHeader) && !string.IsNullOrWhiteSpace(item) && !item.Contains("mo"))
                {
                    // So, not the header and not the empty line.
                    var day = item.Substring(WeatherConfig.DayColumnStart, WeatherConfig.DayColumnLength);
                    var maxTemp = item.Substring(WeatherConfig.MaxTempColumnStart, WeatherConfig.MaxTempColumnLength);
                    var minTemp = item.Substring(WeatherConfig.MinTempColumnStart, WeatherConfig.MinTempColumnLength);

                    if (int.TryParse(day, out var dayAsInt) &&
                        float.TryParse(maxTemp, out var maxTempAsFloat) &&
                        float.TryParse(minTemp, out var minTempAsFloat))
                    {
                        // So all of them parsed correctly.
                        var currentWeather = new Weather
                        {
                            Day = dayAsInt,
                            MaximumTemperature = maxTempAsFloat,
                            MinimumTemperature = minTempAsFloat
                        };

                        results.Add(currentWeather);
                    }
                }
            }

            return results;
        }

    }
}
