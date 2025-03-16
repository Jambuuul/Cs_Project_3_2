using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace project_3_2
{
    public static class SpectreTable
    {
        public static void Run(ref Cities cities)
        {
            Console.Clear();

            Table table = new();

            _ = table.AddColumns("Name", "Country", "Longitude", "Latitude", "Population");
            

            foreach (City c in cities)
            {
                _ = table.AddRow(c.Name,
                    c.Country,
                    c.Longitude.ToString(),
                    c.Latitude.ToString(),
                    c.Population != -1 ? c.Population.ToString() : "Unknown"
                    );
            }
            AnsiConsole.Write(table);
        }
    }
}
 