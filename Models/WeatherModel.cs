using Newtonsoft.Json;

namespace LR9.Models
{
    public class WeatherModel
    {
        [JsonProperty("name")]
        public string Name { get; set; } // Назва міста

        [JsonProperty("main")]
        public Main WeatherMain { get; set; } // Температура, вологість

        [JsonProperty("weather")]
        public List<WeatherDescription> Weather { get; set; } // Опис

        [JsonProperty("wind")]
        public Wind WeatherWind{ get; set; } // Вітер

        public class Main
        {
            [JsonProperty("temp")]
            public float Temp { get; set; }

            [JsonProperty("humidity")]
            public int Humidity { get; set; }

            [JsonProperty("feels_like")]
            public float FeelsLike { get; set; }

            [JsonProperty("temp_min")]
            public float TempMin { get; set; }

            [JsonProperty("temp_max")]
            public float TempMax { get; set; }

            [JsonProperty("pressure")]
            public int Pressure { get; set; }

        }
        public class WeatherDescription
        {
            [JsonProperty("description")]
            public string Description { get; set; }
        }

        public class Wind
        {
            [JsonProperty("speed")]
            public float Speed { get; set; }

            [JsonProperty("deg")]
            public int Deg { get; set; }

            [JsonProperty("gust")]
            public float Gust { get; set; }
        }
    }
}
