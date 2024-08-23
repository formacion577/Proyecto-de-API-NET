using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private static List<WeatherForecast> ListMeatherforecast =new List<WeatherForecast>();


    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(ListMeatherforecast == null || !ListMeatherforecast.Any())
        {
            ListMeatherforecast= Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
       return ListMeatherforecast;        
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListMeatherforecast.Add(weatherForecast);
        return Ok();
    }
    [HttpDelete]
    public IActionResult Delete(int index)
    {
        ListMeatherforecast.RemoveAt(index);
        return Ok();
    }
}