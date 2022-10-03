using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Soccer_parttwo
{
    internal class ReadFile
    {
        private readonly IFileSystem _fileSystem;

        public ReadFile(IFileSystem file)
        {
            _fileSystem = file;
        }

        public IList<Fottball> GetFootballData(string fileLocation)
        {
            // Contract checks.
            if (string.IsNullOrWhiteSpace(fileLocation)) throw new ArgumentNullException(nameof(fileLocation), "The file location can not be null.");

            var file = _fileSystem.File.ReadAllLines(fileLocation);
            if (!file.Any() || !file.First().Contains(AppConstants.FootballHeader)) throw new InvalidDataException("Invalid File Data.  No rows found.");

            var results = new List<Football>();

            foreach (var item in file)
            {
                // Need to use the config to extract out the items...
                if (!item.Equals(AppConstants.FootballHeader) && !item.Equals(AppConstants.FootballDivider))
                {
                    // So, not the header and not the divider line.
                    var team = item.Substring(FootballConfig.TeamColumnStart, FootballConfig.TeamColumnLength);
                    var forPoints = item.Substring(FootballConfig.ForColumnStart, FootballConfig.ForColumnLength);
                    var againstPoints = item.Substring(FootballConfig.AgainstColumnStart, FootballConfig.AgainstColumnLength);

                    if (int.TryParse(forPoints, out var forAsInt) && int.TryParse(againstPoints, out var againstAsInt))
                    {
                        // So, we parsed the points correctly.
                        var currentFootball = new Football
                        {
                            TeamName = team.Trim(),
                            ForPoints = forAsInt,
                            AgainstPoints = againstAsInt
                        };

                        results.Add(currentFootball);
                    }
                }
            }

            return results;
        }

    }
}
