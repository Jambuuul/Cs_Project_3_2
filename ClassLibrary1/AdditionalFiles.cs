using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectLib
{
    public static class AdditionalFiles
    {
        public static void Menu()
        {
            Console.WriteLine("Работа с файлами:");
            Console.WriteLine("" +
                "1. Экспорт CSV\n" +
                "2. Экспорт JSON\n" +
                "3. Импорт CSV\n" +
                "4. Импорт JSON\n" +
                "5. Выход");

            Console.Write("Выберите опцию: ");
        }

        public static void Run(ref Cities cities)
        {
            while (true)
            {
                Console.Clear();
                Menu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        WriteToCsv(ref cities);
                        FileMethods.AskForInput(); break;
                    case "2":
                        WriteToJson(ref cities);
                        FileMethods.AskForInput();
                        break;
                    case "3":
                        ReadCsv(ref cities);
                        FileMethods.AskForInput(); break;
                    case "4":
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Некорректная команда!");
                        FileMethods.AskForInput();
                        continue;
                }
            }
        }

        public static void ReadCsv(ref Cities cites)
        {
            string path = InputPath();
            if (path == "")
            {
                return;
            }
            try
            {
                cites = FileManager.ReadCsv(path);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Файл не удалось сохранить: {e.Message}");
            }
        }

        public static void WriteToCsv(ref Cities cities)
        {
            string path = InputPath();
            if (path == "")
            {
                Console.WriteLine("Ошибка при вводе пути");
                return;
            }
            try
            {
                FileManager.WriteToCsv(path, cities);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Файл не удалось сохранить: {e.Message}");
            }

        }

        public static void WriteToJson(ref Cities cities)
        {
            string path = InputPath();
            if (path == "")
            {
                Console.WriteLine("Ошибка при вводе пути");
                return;
            }
            try
            {
                FileManager.WriteToJson(path, cities);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Файл не удалось сохранить: {e.Message}");
            }
        }

        public static string InputPath()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Перед началом работы введите путь к файлу,\n" +
                        "или пустую строку для выхода: ");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        Console.WriteLine("Некорректный путь!");
                        FileMethods.AskForInput();
                        continue;
                    }

                    return input == "" || !FileMethods.IsValidFullPath(input) ? "" : input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    FileMethods.AskForInput();
                    continue;
                }
            }
        }
    }
}
