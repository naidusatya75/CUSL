using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_parttwo
{
    internal class TeamPerformance
    {
        private readonly ReadFile _fileReader;

        private readonly FootballData _footballNotifier;
        public TeamPerformance(ReadFile reader, FootballData notify)
        {
            // Contract requirements.
            _fileReader = reader ?? throw new ArgumentNullException(nameof(reader), "The file reader can't be null.");
            _footballNotifier = notify ?? throw new ArgumentNullException(nameof(notify), "The football notifier can't be null.");
        }

        public string GetTeamWithLeastPointDifference(string fileLocation)
        {
            // Contract requirements.
            if (string.IsNullOrWhiteSpace(fileLocation)) throw new ArgumentNullException(nameof(fileLocation), "The file location can not be null.");

            var fileData = _fileReader.GetFootballData(fileLocation);
            var result = _footballNotifier.GetTeamWithSmallestPointRange(fileData);

            return result;
        }
    }
}
