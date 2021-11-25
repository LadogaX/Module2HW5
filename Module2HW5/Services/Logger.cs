using System;
using Module2HW5.Services;
using Module2HW5.Services.Abstractions;

namespace Modul2HW5
{
    public class Logger : ILogger
    {
        private readonly IFileService _fileService;

        public Logger(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void Log(LogType type, string message)
        {
            var log = $"{DateTime.UtcNow}: {type.ToString()}: {message}";
            _fileService.Append(log);

            Console.WriteLine(log);
        }

        public void Close()
        {
            _fileService.CloseWriter();
        }
    }
}
