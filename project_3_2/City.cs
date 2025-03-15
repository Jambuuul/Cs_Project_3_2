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
        public int Population { get; set; }

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
        public City(string name, string country, int population, double longitude, double latitude)
            : this(name, country, longitude, latitude)
        {
            Population = population;
        }
    }

}
