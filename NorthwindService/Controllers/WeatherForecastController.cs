using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NorthwindService.Controllers
{
    
    [ApiController]
    // Route("api/forecast") // This will make the relative-path like https://localhost:5001/api/forecast
    [Route("[controller]")] // This cut the word Contoller in the name of controller https://localhost:5001/weatherforecast
    
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly static Random random = new Random();
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // [GET] https://localhost:5001/weatherforecast/
        // 
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
           return Get(5);
        }

        // [GET] https://localhost:5001/weatherforecast/(number:int)
        [HttpGet("{days:int}")]
        public IEnumerable<WeatherForecast> Get(int days){
            return Enumerable.Range(1,days).Select(i => new WeatherForecast{
                Date = DateTime.Now.AddDays(i),
                TemperatureC = random.Next(-20,55),
                Summary = Summaries[random.Next(Summaries.Length)]
            }).ToArray();
        }
    
    }
}
