namespace Core.Dal.DbContext
{
    using Autofac;
    using Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Base class for Db context.
    /// </summary>
    /// <typeparam name="TDbContext">context type.</typeparam>
    public abstract class BaseDbContext<TDbContext> : DbContext, IBaseDbContext
       where TDbContext : BaseDbContext<TDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDbContext{TDbContext}"/> class.
        /// </summary>
        /// <param name="config">context config.</param>
        /// <param name="lifetimeScope">autofac lifetimescope.</param>
        /// <param name="logger">logger.</param>
        /// <param name="loggerFactory">logger factory.</param>
        protected BaseDbContext(IDbContextConfig config, ILifetimeScope lifetimeScope, Core.Logging.ILogger logger, ILoggerFactory loggerFactory)
        {
            this.LifetimeScope = lifetimeScope;
            this.ConnectionString = config.ConnectionString;

            this.Logger = logger;
            this.LoggerFactory = loggerFactory;
        }

        public ILifetimeScope LifetimeScope { get; }

        public Logging.ILogger Logger { get; }

        public ILoggerFactory LoggerFactory { get; }

        public string ConnectionString { get; }

        public abstract string SchemaName { get; }

        #region Configuration

        /// <summary>
        /// Standart method for configuring db context.
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            this.OnConfiguringImplementation(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.OnModelCreatingImplementation(modelBuilder);
        }

        #endregion
    }
}
