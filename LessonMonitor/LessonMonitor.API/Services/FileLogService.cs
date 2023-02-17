using Microsoft.Extensions.Configuration;
using System.IO;

namespace LessonMonitor.API.Services
{
    public class FileLogService : ILogService
    {
        private readonly string _logFileName;

        public FileLogService(IConfiguration configuration)
        {
            _logFileName = configuration["LogFilePath"];
        }

        public void Log(string logData)
        {
            File.AppendAllText(_logFileName, logData);
        }
    }
}
