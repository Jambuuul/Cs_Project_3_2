﻿using ProjectLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib
{
    /// <summary>
    /// Класс для базовой части
    /// </summary>
    public static class BaseTask
    {
        /// <summary>
        /// Меню
        /// </summary>
        public static void BaseMenu()
        {
            Console.WriteLine("Базовый функционал приложения:");
            Console.WriteLine("" +
                "1. Просмотр списка городов\n" +
                "2. Добавление нового города\n" +
                "3. Редактирование информации о городе\n" +
                "4. Удаление города\n" +
                "5. Сохранить обратно в файл\n" +
                "6. Выход в главное меню");

            Console.Write("Выберите опцию: ");
        }

        /// <summary>
        /// Запуск
        /// </summary>
        /// <param name="cities"> города </param>
        /// <param name="path"> путь изначального файла</param>
        public static void Run(ref Cities cities, string path)
        {
            while (true)
            {
                Console.Clear();
                BaseMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();

                        foreach (City city in cities)
                        {
                            Console.WriteLine(city);
                        }

                        FileMethods.AskForInput(); break;
                    case "2":
                        AddCity(ref cities); ; break;
                    case "3":
                        RedactCity(ref cities); break;
                    case "4":
                        DeleteCity(ref cities);
                        break;
                    case "5":
                        FileManager.SaveToFile(path, cities);
                        Console.WriteLine("Файл успешно сохранен!");
                        FileMethods.AskForInput(); 
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Некорректная команда!");
                        FileMethods.AskForInput();
                        continue;
                }
            }
        }

        /// <summary>
        /// Редактирование по названию города
        /// </summary>
        /// <param name="cities"> города </param>
        public static void RedactCity(ref Cities cities)
        {
            Console.Write("Введите имя города:");
            string? name = Console.ReadLine();
            if (name == null || !cities.Contains(name))
            {
                Console.WriteLine($"Город {name} отсутствует в списке");
                FileMethods.AskForInput();
                return;
            }

            Console.WriteLine("Вводите новые параметры.\n" +
                " Если не хотите задавать конкретный, просто нажмите Enter.");

            Console.Write("Введите новую страну: ");
            string? country = Console.ReadLine() ?? "";

            Console.Write("Введите широту: ");
            string? lat = Console.ReadLine() ?? "";

            Console.Write("Введите долготу:");
            string? lon = Console.ReadLine() ?? "";

            Console.Write("Введите население: ");
            string? pop = Console.ReadLine() ?? "";



            bool res = cities.RedactCity(name, country, lat, lon, pop);

            if (res)
            {
                Console.WriteLine("Редактирование прошло успешно.");

            }
            else
            {
                Console.WriteLine("Редактирование не удалось.");
            }

            FileMethods.AskForInput();
            return;
        }

        /// <summary>
        /// добавление города
        /// </summary>
        /// <param name="cities"> города </param>
        public static void AddCity(ref Cities cities)
        {
            Console.Clear();
            Console.WriteLine("Введите в типичном формате строку с данными о городе:");
            string? input = Console.ReadLine();
            if (input == null || !City.TryParse(input, out City? city) || city is null)
            {
                Console.WriteLine("Ошибка при добавлении города!");
                FileMethods.AskForInput();
                return;
            }
            cities.AddCity(city);
        }
        
        /// <summary>
        /// Удаление города
        /// </summary>
        /// <param name="cities"> города </param>
        public static void DeleteCity(ref Cities cities)
        {
            Console.Clear();
            Console.WriteLine("Введите название города, который хотите удалить:");
            string? input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Некорректное имя!");
                FileMethods.AskForInput(); return;
            }

            bool res = cities.RemoveCity(input);
            if (res)
            {
                Console.WriteLine("Город успешно удален.");
            }
            else
            {
                Console.WriteLine("Город отсутствует в списке.");
            }
            FileMethods.AskForInput();
            return;

        }


    }
}
