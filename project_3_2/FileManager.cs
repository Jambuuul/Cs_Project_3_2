﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace project_3_2
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

        public static void WriteToJson(string path)
        {
            //StringBuilder sb = new();
            //_ = sb.Append("{");

            //for (int i = 0; i < _data.Keys.Count; i++)
            //{
            //    string[] keys = [.. _data.Keys];
            //    JsonValue val = _data[keys[i]];
            //    _ = sb.Append($"\"{keys[i]}\" : {val}");
            //    if (i != keys.Length - 1)
            //    {
            //        _ = sb.Append(",");
            //    }
            //}

            //_ = sb.Append("}");
            //return sb.ToString();
        }
    }
}
