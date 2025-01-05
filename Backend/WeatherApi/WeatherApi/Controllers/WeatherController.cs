using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApi.Modal;


[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        var client = _httpClientFactory.CreateClient("OpenWeatherClient");
        var apiKey = _configuration["OpenWeather:ApiKey"];

        // URL'yi doğru bir şekilde oluşturduğumuzu kontrol edelim
        var response = await client.GetAsync($"weather?q={city}&appid={apiKey}&units=metric");

        if (!response.IsSuccessStatusCode)
        {
            // Hata durumunu detaylı görmek için log veya hata mesajı ekleyelim
            var errorContent = await response.Content.ReadAsStringAsync();
            return BadRequest($"API Hatası: {errorContent}");
        }

        var json = await response.Content.ReadAsStringAsync();

        var weatherData = JsonSerializer.Deserialize<WeatherResponse>(json);

        return Ok(weatherData);
    }

}
