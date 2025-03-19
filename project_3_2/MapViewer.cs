using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3_2
{
    public class MapViewer
    {
        public static void Run()
        {
            int consoleWidth = 120;
            int consoleHeight = 30;
            Console.SetWindowSize(consoleWidth, consoleHeight);
            Console.Clear();

            // Создаем буфер для карты
            char[,] mapBuffer = new char[consoleWidth, consoleHeight];

            // Заполняем карту (вода и суша)
            for (int y = 0; y < consoleHeight; y++)
            {
                for (int x = 0; x < consoleWidth; x++)
                {
                    mapBuffer[x, y] = IsLand(x, y, consoleWidth, consoleHeight) ? '█' : ' ';
                }
            }

            // Выводим ASCII-карту
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int y = 0; y < consoleHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                StringBuilder line = new StringBuilder();
                for (int x = 0; x < consoleWidth; x++)
                {
                    line.Append(mapBuffer[x, y]);
                }
                Console.Write(line);
            }

            // Координаты городов
            var cities = new List<Tuple<double, double, char>>
            {
                Tuple.Create(48.8566, 2.3522, 'P'), // Париж
                Tuple.Create(40.7128, -74.0060, 'N'), // Нью-Йорк
                Tuple.Create(-23.5505, -46.6333, 'S'), // Сан-Паулу
                Tuple.Create(35.6895, 139.6917, 'T')  // Токио
            };

            // Отмечаем города поверх карты
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var city in cities)
            {
                int x = (int)Math.Round((city.Item2 + 180) * (consoleWidth - 1) / 360.0);
                int y = (int)Math.Round((90 - city.Item1) * (consoleHeight - 1) / 180.0);

                x = Math.Clamp(x, 0, consoleWidth - 1);
                y = Math.Clamp(y, 0, consoleHeight - 1);

                Console.SetCursorPosition(x, y);
                Console.Write(city.Item3);
            }

            Console.SetCursorPosition(0, consoleHeight - 1);
            Console.ResetColor();
            Console.WriteLine("Карта мира: █ - суша, метки городов выделены цветом");
            _ = Console.ReadLine();
        }

        // Упрощенная проверка на принадлежность к суше
        static bool IsLand(int x, int y, int width, int height)
        {
            double lon = (x * 360.0 / width) - 180;
            double lat = 90 - (y * 180.0 / height);

            // Северная Америка
            if (lat > 10 && lat < 70 && lon > -130 && lon < -60) return true;

            // Южная Америка
            if (lat > -56 && lat < 12 && lon > -85 && lon < -30) return true;

            // Европа/Азия
            if (lat > 35 && lat < 75 && lon > -20 && lon < 140) return true;

            // Африка
            if (lat > -35 && lat < 35 && lon > -20 && lon < 55) return true;

            // Австралия
            if (lat > -45 && lat < -10 && lon > 110 && lon < 155) return true;

            return false;
        }
    }
}
