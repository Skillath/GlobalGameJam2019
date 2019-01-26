using System;

namespace GGJ2019.Utils.Entities
{
    public interface ILogger
    {
        void Log(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogException(Exception exception);
        void LogAssertion(string message);
    }
}
