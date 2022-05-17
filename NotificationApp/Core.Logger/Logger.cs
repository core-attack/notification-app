namespace Core.Logging
{
    using System;
    using Serilog.Events;

    public sealed class Logger : ILogger
    {
        public const string EllapsedMillisecondsProperty = "EllapsedMilliseconds";

        public const string CorrelationIdProperty = "CorrelationId";

        public const string LogTypeIndexName = "LogType";

        public const string ApplicationLogTypeName = "Application";

        private readonly Serilog.ILogger _appLogger;

        public Logger(Serilog.ILogger logger)
        {
            _appLogger = logger;
        }

        public void LogInfo(string messageTemplate, params object[] propertyValues)
        {
            WriteAppLog(LogEventLevel.Information, null, messageTemplate, propertyValues);
        }

        public void LogDebug(string messageTemplate, params object[] propertyValues)
        {
            WriteAppLog(LogEventLevel.Debug, null, messageTemplate, propertyValues);
        }

        public void LogWarning(string messageTemplate, params object[] propertyValues)
        {
            WriteAppLog(LogEventLevel.Warning, null, messageTemplate, propertyValues);
        }

        public void LogException(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            WriteAppLog(LogEventLevel.Error, exception, messageTemplate, propertyValues);
        }

        public void LogError(string messageTemplate, params object[] propertyValues)
        {
            WriteAppLog(LogEventLevel.Error, null, messageTemplate, propertyValues);
        }

#pragma warning disable Serilog004 // Constant MessageTemplate verifier
        private void WriteAppLog(LogEventLevel level, Exception? exception, string messageTemplate, params object[] propertyValues)
        {
            _appLogger.Write(level, exception, messageTemplate, propertyValues);
        }
#pragma warning restore Serilog004 // Constant MessageTemplate verifier
    }
}
