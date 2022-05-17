namespace Core.Dal.DbContext
{
    using Autofac;
    using Microsoft.Extensions.Logging;

    public interface IBaseDbContext
    {
        ILifetimeScope LifetimeScope { get; }

        Core.Logging.ILogger Logger { get; }

        ILoggerFactory LoggerFactory { get; }

        string ConnectionString { get; }

        abstract string SchemaName { get; }

        virtual string MigrationsHistorySchemaName => SchemaName;
    }
}
