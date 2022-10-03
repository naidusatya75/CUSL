using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Soccer_parttwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello.");

            var reader = new ReadFile(new FileSystem());
            var football = new FootballData();
            var processor = new TeamPerformance(reader, football);

            Console.WriteLine($"Processing the file '{ConfigVal.FullFileName}'.");
            try
            {
                var result = processor.GetTeamWithLeastPointDifference(ConfigVal.FullFileName);

                Console.WriteLine($"The result is: {result}.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"The application threw the following exception: {exception.Message}.");
            }

            Console.WriteLine("I hoped you enjoyed it!");
        }
    }
}
