namespace WeatherAPI.Services
{
	public interface IWeatherService
	{
		IEnumerable<WeatherForecast> GetForecasts();

		void CreateForecast(string forecast);

		void CreateWeatherForecast(WeatherForecast weather);

		int GetErrors();
	}
}
