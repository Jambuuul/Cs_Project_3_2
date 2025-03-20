using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectLib
{
    /// <summary>
    /// Структура для данных о погоде
    /// </summary>
    public struct WeatherData
    {
        [JsonPropertyName("main")]
        public MainData Main { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherDescription> Weather { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Структура основных данных
        /// </summary>
        public struct MainData
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }
        }

        /// <summary>
        /// Структура для описания погоды
        /// </summary>
        public struct WeatherDescription
        {
            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }
        }
    }
}
