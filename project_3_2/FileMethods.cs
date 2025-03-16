using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3_2
{
    /// <summary>
    /// Статический класс с методами для работы с файлами
    /// </summary>
    public static class FileMethods
    {
        /// <summary>
        /// Проверяет путь до файла на корректность
        /// </summary>
        /// <param name="path"> путь </param>
        /// <returns>true, если путь корректен</returns>
        public static bool IsValidFullPath(string path)
        {
            try
            {
                // вызывет исключение, если путь неправильный
                string fullPath = Path.GetFullPath(path);
                return File.Exists(fullPath);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
