using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPart_one
{
    internal class WeatherDataManager
    {
        private readonly FileExtractor _fileReader;
        private readonly WeatherData _weatherData;

        public WeatherDataManager(FileExtractor reader, WeatherData notify)
        {
            // Contract requirements.
            if (reader is null) throw new ArgumentNullException(nameof(reader), "The file extractor can not be null.");
            if (notify is null) throw new ArgumentNullException(nameof(notify), "The data processor can not be null.");

            _fileReader = reader;
            _weatherData = notify;
        }

        public int GetDayWithLeastChange(string fileLocation)
        {
            // Contract requirements.
            if (string.IsNullOrWhiteSpace(fileLocation)) throw new ArgumentNullException(nameof(fileLocation), "The file location can not be null.");

            var fileData = _fileReader.GetWeatherData(fileLocation);
            int result = _weatherData.GetDayOfLeastTemperatureChange(fileData);

            return result;
        }
    }
}
