using System;
using System.IO;

namespace LessonMonitor.API.Services
{
    public class FileLogService: ILogService
    {
        private readonly string _pathToFile;

        public FileLogService()
        {
            _pathToFile = $"log_{DateTime.Today.ToShortDateString()}.log";
        }

        public void Log(string message)
        {
            File.AppendAllText(_pathToFile, $"[{DateTime.Now}] {message}\n");
        }
    }
}
