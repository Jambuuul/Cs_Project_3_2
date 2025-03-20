using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib
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
                if (File.Exists(fullPath)) 
                {
                    return true;
                }

                File.WriteAllText(fullPath, string.Empty);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void AskForInput()
        {
            Console.WriteLine("Введите Enter для продолжения...");
            _ = Console.ReadKey();
        }


    }
}
