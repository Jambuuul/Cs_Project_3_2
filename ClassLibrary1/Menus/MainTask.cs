using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib
{
    /// <summary>
    /// Класс для основной части 
    /// </summary>
    public static class MainTask
    {
        /// <summary>
        /// Меню
        /// </summary>
        public static void MainTaskMenu()
        {
            Console.WriteLine("Основной функционал:");
            Console.WriteLine("" +
                "1. Визуализация таблицы с помощью Spectre\n" +
                "2. Отображение города на карте\n" +
                "3. Выход в главное меню");

            Console.Write("Выберите опцию: ");
        }


        /// <summary>
        /// Запуск
        /// </summary>
        /// <param name="cities">города</param>
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
                        FileMethods.AskForInput(); break;
                    case "2":
                        MapViewer.Run(ref cities);
                        FileMethods.AskForInput();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректная команда!");
                        FileMethods.AskForInput();
                        continue;
                }
            }
        }


    }
}
