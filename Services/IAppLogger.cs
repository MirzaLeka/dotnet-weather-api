namespace WeatherAPI.Services
{
	public interface IAppLogger<in T> where T : class
	{
		public void LogInformation(string message, params object[] args);

		public void LogWarning(string message, params object[] args);

		public void LogError(Exception ex, string message, params object[] args);

		public void LogCritical(Exception ex, string message, params object[] args);

	}
}
