namespace Core.Logging
{
    using System;

    public interface ILogger
    {
        void LogInfo(string messageTemplate, params object[] propertyValues);

        void LogDebug(string messageTemplate, params object[] propertyValues);

        void LogWarning(string messageTemplate, params object[] propertyValues);

        void LogException(Exception exception, string messageTemplate, params object[] propertyValues);

        void LogError(string messageTemplate, params object[] propertyValues);
    }
}
