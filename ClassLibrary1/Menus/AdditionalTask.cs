using ProjectLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib
{
    /// <summary>
    /// Класс для доп части
    /// </summary>
    public static class AdditionalTask
    {
        /// <summary>
        /// Меню
        /// </summary>
        public static void AddTaskMenu()
        {
            Console.WriteLine("Дополнительныйф функционал:");
            Console.WriteLine("" +
                "1. OpenStreetMap\n" +
                "2. Погода\n" +
                "3. Импорт/экспорт\n" +
                "4. Выход в главное меню");

            Console.Write("Выберите опцию: ");
        }

        /// <summary>
        /// Запуск
        /// </summary>
        /// <param name="cities"> города </param>
        public static void Run(ref Cities cities)
        {
            while (true)
            {
                Console.Clear();
                AddTaskMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        
                        FileMethods.AskForInput(); break;
                    case "2":
                        // TODO: починить асинхронность
                        WeatherInfo();
                        FileMethods.AskForInput(); break;
                    case "3":
                        AdditionalFiles.Run(ref cities);
                        FileMethods.AskForInput();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Некорректная команда!");
                        FileMethods.AskForInput();
                        continue;
                }
            }
        }

        /// <summary>
        /// Выводит информацию о погоде
        /// </summary>
        public static void WeatherInfo()
        {
            string name = AnsiConsole.Prompt(
                    new TextPrompt<string>("Введите название первого города:"));

            _ = WeatherManager.DisplayWeather(name);

        }
    }
}
