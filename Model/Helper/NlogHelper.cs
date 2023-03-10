using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace ConsoleAppSample.Model.Helper
{
    public class NlogHelper
    {
		protected static readonly Microsoft.Extensions.Logging.ILogger logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();
			
		public enum LogType
		{
			Info,
			Error,
			Debug
		}

		public static void LogWrite(String msg, LogType logtype = LogType.Info)
		{
			Console.WriteLine(msg);

			switch (logtype)
			{
				case LogType.Info:
					logger.LogInformation(msg);
					break;
				case LogType.Error:
					logger.LogError(msg);
					break;
				case LogType.Debug:
					logger.LogDebug(msg);
					break;
				default:
					break;
			}
		}
    }
}
