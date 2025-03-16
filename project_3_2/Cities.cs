using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace project_3_2
{
    public class Cities
    {
        private readonly  Dictionary<string, City> _cities;


        public Cities()
        {
            _cities = [];
        }

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

        public bool Contains(string name)
        {
            return _cities.ContainsKey(name);
        }

        public bool RemoveCity(string name)
        {
            
            return _cities.Remove(name);
            
        }

        public void PrintInfo()
        {
            foreach ((_, City city) in _cities)
            {
                Console.WriteLine(city);
            }
        }
    }
}
