using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace ConsoleAppSample.Model.Helper
{
    public class NlogHelper
    {
        private static readonly ILogger logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

		public static void Log(String msg, LogType logtype = LogType.Info)
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

        public static void Log(object obj)
        {
            Log($"{obj.GetType()}: {JsonSerializer.Serialize(obj, options)}");
        }
    }
    public enum LogType
    {
        Info,
        Error,
        Debug
    }
}
