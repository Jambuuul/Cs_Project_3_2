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
                if (File.Exists(fullPath) || Path.IsPathRooted(fullPath)) 
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Запрос ввода пользователя для продолжения
        /// </summary>
        public static void AskForInput()
        {
            Console.WriteLine("Введите Enter для продолжения...");
            _ = Console.ReadKey();
        }


    }
}
