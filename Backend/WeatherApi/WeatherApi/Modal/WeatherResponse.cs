using System.Text.Json.Serialization;

namespace WeatherApi.Modal
{
    public class WeatherResponse
    {
       
       [JsonPropertyName("name")]
       public string CityName { get; set; }

       [JsonPropertyName("main")]
       public MainInfo Main { get; set; }

       [JsonPropertyName("weather")]
       public List<WeatherInfo> Weather { get; set; }

       [JsonPropertyName("wind")]
       public WindInfo Wind { get; set; }
        }

        public class MainInfo
        {
            [JsonPropertyName("temp")]
            public float Temperature { get; set; }
        }

        public class WeatherInfo
        {
            [JsonPropertyName("description")]
            public string Description { get; set; }
        }

        public class WindInfo
        {
            [JsonPropertyName("speed")]
            public float Speed { get; set; }
        }
    }

