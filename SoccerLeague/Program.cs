using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SoccerLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("c:\\satya\\weather1.txt");
            List<Parser.Row> rows = Parser.ParseWeather(input);
            Parser.Row dayWithSmallestSpread = rows
                .OrderBy(x => x.AbsDiff)
                .First();
            Console.WriteLine($"Day: {dayWithSmallestSpread.Name}" +
                $" min: {dayWithSmallestSpread.ValueB}" +
                $" max: {dayWithSmallestSpread.ValueA}" +
                $" spread: {dayWithSmallestSpread.AbsDiff}");

            input = File.ReadAllText("c:\\satya\\football1.txt");
            var teamWithSmallestDiff = Parser.ParseFootball(input)
                .OrderBy(x => x.AbsDiff)
                .First();
            Console.WriteLine($"Day: {teamWithSmallestDiff.Name}" +
                $" against: {teamWithSmallestDiff.ValueA}" +
                $" for: {teamWithSmallestDiff.ValueB}" +
                $" diff: {teamWithSmallestDiff.AbsDiff}");
            Console.WriteLine("I hoped you enjoyed it!");

        }
    }
}
