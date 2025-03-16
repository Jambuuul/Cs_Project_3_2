﻿using System;
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

        public void RedactCity(string name)
        {

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
