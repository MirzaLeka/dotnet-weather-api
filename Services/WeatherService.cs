using System.Text.Json;

namespace WeatherAPI.Services
{
	public class WeatherService(ILogger<WeatherService> logger) : IWeatherService
	{
		private static List<string> Summaries = new()
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherService> _logger = logger;

		public IEnumerable<WeatherForecast> GetForecasts()
		{
			var array = Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Count)]
			})
			.ToArray();

			_logger.LogWarning("First array {forecast}", array[0]);
			_logger.LogWarning("First summary {summary}", Summaries[0]);

			return array;
		}

		public void CreateForecast(string forecast)
		{
			_logger.LogInformation("Provided message: {forecast}", forecast);
			_logger.LogWarning("Provided message: {forecast}", forecast);

			Summaries.Add(forecast);

			_logger.LogWarning("Added message: {forecast}. TOtal {summaries}", forecast, Summaries.Count);

		}

		public int GetErrors()
		{
			try
			{
				throw new NotImplementedException();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Message was: {message}. Inner exp was: {innerEx}, Status is: {status}", ex.Message, ex.InnerException?.Message, 500);
				return 500;
			}
		}

		public void CreateWeatherForecast(WeatherForecast weather)
		{
			_logger.LogWarning("Added weather @{weather}", new { weather, date = DateTime.Now });

			_logger.LogWarning("Added weather serialized {weather}", JsonSerializer.Serialize(weather));

			_logger.LogWarning("Added weather @{weather}, {event_name}", new { weather }, EventName.ADD_WEATHER);
			_logger.LogInformation("Added weather @{weather}, {event_name}", new { weather }, EventName.ADD_WEATHER);

		}

	}
}
