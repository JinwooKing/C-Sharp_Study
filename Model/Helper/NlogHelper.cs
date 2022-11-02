using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace ConsoleAppSample.Model.Helper
{
    public class NlogHelper
    {       
        public NlogHelper(){
            var logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();

            logger.LogInformation("Program has started.");
        }
    }
}
