using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3_2
{
    internal class Cities
    {
        private readonly  Dictionary<string, City> _cities;


        public Cities()
        {
            _cities = [];
        }

        public void AddCity(City city)
        {
            // TODO: создавать класс города внутри
            // этого метода, чтобы ссылка не была за пределом класса
            string name = city.Name;
            if (_cities.ContainsKey(name) )
            {
                _cities[name] = city;
            }
            else
            {
                _cities.Add(name, city);
            }

        }

        public void RedactCity(string name)
        {

        }

        public void RemoveCity(string name)
        {
            if ( _cities.ContainsKey(name) )
            {
                _ = _cities.Remove(name);
            }
        }
    }
}
