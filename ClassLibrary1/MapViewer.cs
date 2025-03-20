using ProjectLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLib
{
    public class MapViewer
    {
        public static void Run(ref Cities cities)
        {
            int consoleWidth = 120;
            int consoleHeight = 30;
            Console.SetWindowSize(consoleWidth, consoleHeight);
            Console.Clear();

            
            char[,] mapBuffer = new char[consoleWidth, consoleHeight];


            for (int y = 0; y < consoleHeight; y++)
            {
                for (int x = 0; x < consoleWidth; x++)
                {
                    mapBuffer[x, y] = ' ';
                }
            }


            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.Write(new string('═', consoleWidth));
            Console.SetCursorPosition(0, consoleHeight - 2);
            Console.Write(new string('═', consoleWidth));

            Console.SetCursorPosition((consoleWidth / 2) - 2, 1);
            Console.Write("[N]");
            Console.SetCursorPosition((consoleWidth / 2) - 2, consoleHeight - 3);
            Console.Write("[S]");
            Console.SetCursorPosition(2, (consoleHeight / 2) - 1);
            Console.Write("[W]");
            Console.SetCursorPosition(consoleWidth - 5, (consoleHeight / 2) - 1);
            Console.Write("[E]");


            Console.ForegroundColor = ConsoleColor.Red;
            foreach (City city in cities)
            {
                int x = (int)Math.Round((city.Longitude + 180) * (consoleWidth - 1) / 360.0);
                int y = (int)Math.Round((90 - city.Latitude) * (consoleHeight - 1) / 180.0);

                x = Math.Clamp(x, 0, consoleWidth - 1);
                y = Math.Clamp(y, 0, consoleHeight - 1);

                y += 1;

                Console.SetCursorPosition(x, y);
                char letter = city.Name.Length == 0 ? '?' : city.Name[0];
                Console.Write(letter);
            }

            Console.SetCursorPosition(0, consoleHeight - 1);
            Console.ResetColor();
        }

    }
}
