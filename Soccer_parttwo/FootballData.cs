using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_parttwo
{
    internal class FootballData
    {
        public string GetTeamWithSmallestPointRange(IList<Fottball> footballData)
        {
            // Contract requirements.
            if (footballData is null) throw new ArgumentNullException(nameof(footballData), "The football data can not be null.");
            if (footballData.Count < 1) throw new ArgumentException(nameof(footballData), "The football data must contain data.");

            var teamWithSmallestPointRange = string.Empty;
            var smallestRange = int.MaxValue;

            foreach (var data in footballData)
            {
                // Contract requirements.
                if (data.ForPoints < 0 || data.AgainstPoints < 0) throw new DataMisalignedException("Invalid data: Points can't be less than zero.");

                var range = Math.Abs(data.ForPoints - data.AgainstPoints);

                if (range < smallestRange)
                {
                    smallestRange = range;
                    teamWithSmallestPointRange = data.TeamName;
                }
            }

            return teamWithSmallestPointRange;
        }
    }
}
