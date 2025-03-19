using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3_2.Menus
{
    public class AdditionalTask
    {
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
                        
                        Program.AskForInput(); break;
                    case "2":
                        // TODO: починить асинхронность
                        WeatherInfo();
                        Program.AskForInput(); break;
                    case "3":
                        AdditionalFiles.Run(ref cities);
                        Program.AskForInput();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Некорректная команда!");
                        Program.AskForInput();
                        continue;
                }
            }
        }

        public static void WeatherInfo()
        {
            string name = AnsiConsole.Prompt(
                    new TextPrompt<string>("Введите название первого города:"));

            _ = WeatherManager.DisplayWeather(name);

        }
    }
}
