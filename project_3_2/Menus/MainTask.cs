using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3_2.Menus
{
    public static class MainTask
    {
        public static void MainTaskMenu()
        {
            Console.WriteLine("Основной функционал:");
            Console.WriteLine("" +
                "1. Визуализация таблицы с помощью Spectre\n" +
                "2. Отображение города на карте\n" +
                "3. Выход в главное меню");

            Console.Write("Выберите опцию: ");
        }
        public static void Run(ref Cities cities)
        {
            while (true)
            {
                Console.Clear();
                MainTaskMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SpectreTable.Run(ref cities);
                        Program.AskForInput(); break;
                    case "2":
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректная команда!");
                        Program.AskForInput();
                        continue;
                }
            }
        }


    }
}
