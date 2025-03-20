using ProjectLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectLib
{
    /// <summary>
    /// Класс городов
    /// </summary>
    public class Cities : IEnumerable<City>
    {
        private readonly  Dictionary<string, City> _cities;

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Cities()
        {
            _cities = [];
        }

        /// <summary>
        /// Конструктор на основе коллекции городов
        /// </summary>
        /// <param name="cities"> список городов </param>
        public Cities(IEnumerable<City> cities) : this()
        {
            foreach (City city in cities)
            {
                string name = city.Name;
                if (!_cities.TryAdd(name, city))
                {
                    _cities[name] = city;
                }
            }
        }

        /// <summary>
        /// добавление города
        /// </summary>
        /// <param name="city"> город </param>
        public void AddCity(City city)
        {
            // TODO: создавать класс города внутри
            // этого метода, чтобы ссылка не была за пределом класса
            string name = city.Name;
            if (!_cities.TryAdd(name, city))
            {
                _cities[name] = city;
            }
        }

        /// <summary>
        /// Редактирование города по названию
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <param name="pop"></param>
        /// <returns> true, если удалось</returns>
        public bool RedactCity(string name, string country, string lat, string lon, string pop)
        {
            if (!Contains(name))
            {
                return false;
            }

            string newC = _cities[name].Country;
            double newLat = _cities[name].Latitude;
            double newLon = _cities[name].Longitude;
            int newPop = _cities[name].Population;
            if (country != "")
            {
                newC = country;
            }
            if (lat != "")
            {
                if (!double.TryParse(lat, out newLat))
                {
                    return false;
                }
            }
            if (lon != "")
            {
                if (!double.TryParse(lat, out newLon))
                {
                    return false;
                }
            }
            if (pop != "")
            {
                if (!int.TryParse(pop, out newPop))
                {
                    return false;
                }
            }

            try
            {
                _cities[name] = new City(name, newC, newLon, newLat, newPop);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Находится ли город в списке
        /// </summary>
        /// <param name="name"> имя города </param>
        /// <returns>true, если да</returns>
        public bool Contains(string name)
        {
            return _cities.ContainsKey(name);
        }

        /// <summary>
        /// Удаление города по названию
        /// </summary>
        /// <param name="name"> название </param>
        /// <returns>true, если удалось</returns>
        public bool RemoveCity(string name)
        {
            
            return _cities.Remove(name);
            
        }

        /// <summary>
        /// Возвращает итератор
        /// </summary>
        /// <returns>итератор</returns>
        public IEnumerator<City> GetEnumerator()
        {
            return _cities.Values.GetEnumerator();
        }

        /// <summary>
        /// Возвращает итератор
        /// </summary>
        /// <returns>итератор</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cities.Values.GetEnumerator();
        }
    }
}
