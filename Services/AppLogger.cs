namespace WeatherAPI.Services
{
	public class AppLogger<T>(ILogger<T> logger) : IAppLogger<T> where T : class
	{
		public void LogInformation(string message, params object[] args)
		{
			logger.LogInformation(message, SanitizeArgs(args));
		}

		public void LogWarning(string message, params object[] args)
		{
			logger.LogWarning(message, SanitizeArgs(args));
		}

		public void LogError(Exception ex, string message, params object[] args)
		{
			logger.LogError(ex, message, SanitizeArgs(args));
		}

		public void LogCritical(Exception ex, string message, params object[] args)
		{
			logger.LogCritical(ex, message, SanitizeArgs(args));
		}

		private object[] SanitizeArgs(object[] args)
		{
			if (args == null || args.Length == 0)
				return args;

			var sanitized = new object[args.Length];

			for (int i = 0; i < args.Length; i++)
			{
				sanitized[i] = args[i] is string s
					? SanitizeString(s)
					: args[i];
			}

			return sanitized;
		}

		private string SanitizeString(string input)
		{
			if (input == null)
				return null;

			return input
				.Replace("\r", string.Empty)
				.Replace("\n", string.Empty);
		}
	}
}
