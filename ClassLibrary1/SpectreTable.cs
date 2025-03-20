using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ProjectLib
{
    /// <summary>
    /// Статический класс для задния с выводом красивой таблицы
    /// </summary>
    public static class SpectreTable
    {
        /// <summary>
        /// Запуск
        /// </summary>
        /// <param name="cities"> города </param>
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

            bool confirmation = AnsiConsole.Prompt(
                new ConfirmationPrompt("Выбрать города из списка?"));

            if (confirmation)
            {
                string name1 = AnsiConsole.Prompt(
                    new TextPrompt<string>("Введите название первого города:"));

                string name2 = AnsiConsole.Prompt(
                    new TextPrompt<string>("Введите название второго города:"));

                if (!cities.Contains(name1) || !cities.Contains(name2))
                {
                    Console.WriteLine("Как минимум, одного города в списке нет.");
                } else
                {
                    Console.WriteLine($"Вы выбрали следующие города: {name1} и {name2}.\n" +
                        $"В данный момент с ними нельзя ничего сделать, так как " +
                        $"заданием это не предусмотрено.\n" +
                        $"Просят только реализовать возможность выбора городов.\nНо зато вы можете их выбрать, полагаю...");
                }
            }
        }
    }
}
 