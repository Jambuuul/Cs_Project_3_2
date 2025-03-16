using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3_2
{
    /// <summary>
    /// Класс, хранящий информацию о городе
    /// </summary>
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        
        // -1, если данных нет
        public int Population { get; set; } = -1;

        // TODO: проверка коррекнтости значений
        public double Longitude { get; set; }
        public double Latitude { get; set; }


        /// <summary>
        /// Конструктор без населениея
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public City(string name, string country, double longitude, double latitude)
        {
            Name = name;
            Country = country;
            if (Math.Abs(latitude) > 90 || Math.Abs(longitude) > 180)
            {
                throw new ArgumentException("Некорректные координаты");
            }

            Longitude = longitude;
            Latitude = latitude;
        }

        /// <summary>
        /// Конструктор с населением
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="population"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public City(string name, string country, double longitude, double latitude, int population)
            : this(name, country, longitude, latitude)
        {
            Population = population;
        }


        /// <summary>
        /// Парсит строку в City
        /// </summary>
        /// <param name="s"> строка </param>
        /// <returns> город </returns>
        public static bool TryParse(string s, out City? city)
        {
            city = null;
            if (!s.Contains(';'))
            {
                return false;
            }
            string[] str = s.Split(';');

            // всего 4 или 5 параметров

            if (str.Length is < 4 or > 5)
            {
                return false;
            }

            if (!double.TryParse(str[2], out double latitude) ||
                !double.TryParse(str[3], out double longitude))
            {
                return false;
            }

            if (str.Length == 5)
            {
                if (!int.TryParse(str[4], out int population))
                {
                    return false;
                }

                city = new City(str[0], str[1], longitude, latitude, population);
                return true;
            }

            city = new City(str[0], str[1], longitude, latitude);
            return true;

        }

        public override string ToString()
        {

            string s = $"Name: {Name}, Country: {Country}, Lat: {Latitude}, Long: {Longitude}";
            if (Population >= 0)
            {
                s += $", Population: {Population}";
            }
            return s;
        }
    }

}
