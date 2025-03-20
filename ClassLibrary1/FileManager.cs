using ProjectLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ProjectLib
{
    /// <summary>
    /// Класс, отвечающий за чтение/запись файлов
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Парсит файл в объект Cities
        /// </summary>
        /// <param name="path"> путь до файла</param>
        /// <returns> города </returns>
        /// <exception cref="ArgumentNullException"> при некорректном пути</exception>
        public static Cities ReadFile(string path)
        {
            if (path == null || !FileMethods.IsValidFullPath(path))
            {
                throw new ArgumentNullException("Некорректный путь");
            }

            string[] lines = File.ReadAllLines(path);

            List<City> cities = [];

            foreach (string line in lines)
            {
                if (City.TryParse(line, out City? city) && city is not null)
                {
                    cities.Add(city);
                }
            }

            return new Cities(cities);

        }

        /// <summary>
        /// Сохранение в файл в формате .txt, который читается при изначальном запуске
        /// </summary>
        /// <param name="path"> путь </param>
        /// <param name="cities"> города </param>
        /// <exception cref="ArgumentNullException"> при некорректном пути </exception>
        public static void SaveToFile(string path, Cities cities)
        {
            if (path == null || !FileMethods.IsValidFullPath(path))
            {
                throw new ArgumentNullException("Некорректный путь");
            }
            
            StringBuilder sb = new();
            foreach (City city in cities)
            {
                sb.AppendLine(city.ToCsvString()); 
            }
            
            File.WriteAllText(path, sb.ToString());
        }

        /// <summary>
        /// Запись в CSV-файл
        /// </summary>
        /// <param name="path">путь </param>
        /// <param name="cities"> города </param>
        /// <exception cref="ArgumentNullException"> при некорректном пути</exception>
        public static void WriteToCsv(string path, Cities cities)
        {

            if (path == null || !FileMethods.IsValidFullPath(path))
            {
                throw new ArgumentNullException("Некорректный путь");
            }

            StringBuilder sb = new ();
            _ = sb.AppendLine("name;country;latitude;longitude;population");

            foreach (City? city in cities)
            {
                _ = sb.AppendLine(city.ToCsvString());
            }
            File.WriteAllText(path, sb.ToString());
            
        }

        /// <summary>
        /// Чтение из CSV-файла
        /// </summary>
        /// <param name="path">путь</param>
        /// <returns> города </returns>
        public static Cities ReadCsv(string path)
        {
            string[] lines = File.ReadAllLines(path);

            List<City> cities = [];

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (City.TryParse(line, out City? city) && city is not null)
                {
                    cities.Add(city);
                }
            }

            return new Cities(cities);
        }

        /// <summary>
        /// Запись в формат JSON
        /// </summary>
        /// <param name="path"> путь </param>
        /// <param name="cities"> города </param>
        /// <exception cref="ArgumentNullException"> при некорректном пути</exception>
        public static void WriteToJson(string path, Cities cities)
        {
            
            if (path == null || !FileMethods.IsValidFullPath(path))
            {
                throw new ArgumentNullException("Некорректный путь");
            }
            
            StringBuilder sb = new();
            _ = sb.Append("{");
            
            _ = sb.Append("\"cities\":");
            _ = sb.Append('[');

            for (int i = 0; i < cities.Count(); i++)
            {
                
                _ = sb.Append(cities.ElementAt(i).ToJsonObject());
                if (i != cities.Count() - 1)
                {
                    _ = sb.Append(",");
                }
            }

            _ = sb.Append(']');
            _ = sb.Append("}");
            File.WriteAllText(path, sb.ToString());
            
            Console.WriteLine("Файл успешно сохранен!");
        }
    }
}
