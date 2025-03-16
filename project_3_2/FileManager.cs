using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3_2
{
    /// <summary>
    /// Класс, отвечающий за чтение/запись файлов
    /// </summary>
    public static class FileManager
    {
        public static Cities ReadFile(string path)
        {
            if (path == null || !FileMethods.IsValidFullPath(path))
            {
                throw new ArgumentNullException("""Некорректный путь""");
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

        }
    }
}
