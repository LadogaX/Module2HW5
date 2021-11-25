using Modul2HW5;

namespace Module2HW5.Services.Abstractions
{
    public interface ILogger
    {
        void LogInfo(string message);

        void LogError(string message);

        void LogWarning(string message);

        void Log(LogType type, string message);

        void Close();
    }
}