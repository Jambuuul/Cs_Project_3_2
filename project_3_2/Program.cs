
/*
 * Абдулов Джамал Олегович
 * БПИ 248-1
 * Пересдача проекта 3_2
 * B-side
 * Вариант 5
*/


using ProjectLib;

namespace project_3_2
{
    /// <summary>
    /// Класс Program консольного приложения
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Метод Main консольного приложения
        /// </summary>
        public static void Main()
        {
            Cities cities;

            string? path;

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Перед началом работы введите путь к файлу,\n" +
                        "или пустую строку для выхода: ");
                    path = Console.ReadLine();
                    if (path == null)
                    {
                        Console.WriteLine("Некорректный путь!");
                        AskForInput();
                        continue;
                    }
                    if (path == "")
                    {
                        System.Environment.Exit(0);
                    }

                    cities = FileManager.ReadFile(path);
                    break;
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    AskForInput();
                    continue;
                }
            }


            while (true)
            {
                Console.Clear();
                PrintMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        BaseTask.Run(ref cities, path); break;
                    case "2":
                        MainTask.Run(ref cities); break;
                    case "3":
                        AdditionalTask.Run(ref cities); break;
                    case "4":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Некорректная команда!");
                        break;
                }
                AskForInput();
            }

        }

        public static void PrintMenu()
        {
            Console.WriteLine("Добро пожаловать в приложение City Manager!\n" +
                "Выберите, какую часть запустить.\n");

            Console.WriteLine("" +
                "1. Базовая часть\n" +
                "2. Основная часть\n" +
                "3. Дополнительная часть\n" +
                "4. Выход");

            Console.Write("Выберите опцию: ");
        }

        public static void AskForInput()
        {
            Console.WriteLine("Введите Enter для продолжения...");
            _ = Console.ReadKey();
        }
    }
}
