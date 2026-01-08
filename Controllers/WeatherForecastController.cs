using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IWeatherService weatherService) : ControllerBase
    {
		private readonly IWeatherService _weatherService = weatherService;

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherService.GetForecasts();
		}

		[HttpPost("CreateForecast")]
		public IActionResult Create([FromBody] string forecast)
		{
			_weatherService.CreateForecast(forecast);
			return Ok("Done!");
		}

		[HttpPost("CreateWeatherForecast")]
		public IActionResult CreateWeather([FromBody] WeatherForecast weather)
		{
			_weatherService.CreateWeatherForecast(weather);
			return Ok("Done!");
		}

		[HttpGet("GetError")]
		public IActionResult GetError()
		{
			var resp = _weatherService.GetErrors();
			return Ok(resp);
		}
	}
}
