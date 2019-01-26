using System;
using UnityEngine;
using ILogger = GGJ.Utils.Entities.ILogger;

namespace GGJ.UnityUtils.Entities
{
    public class Logger : ILogger
    {
        public void Log(string message) => Debug.Log(message);

        public void LogAssertion(string message) => Debug.LogAssertion(message);

        public void LogError(string message) => Debug.LogError(message);

        public void LogException(Exception exception) => Debug.LogException(exception);

        public void LogWarning(string message) => Debug.LogWarning(message);
    }
}
