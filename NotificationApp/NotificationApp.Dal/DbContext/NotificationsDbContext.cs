namespace NotificationApp.Dal.DbContext
{
    using Autofac;
    using Core.Dal.Configuration;
    using Core.Dal.DbContext;
    using Core.Logging;
    using DbModels;
    using Microsoft.EntityFrameworkCore;
    using Npgsql;
    using Npgsql.NameTranslation;

    public class NotificationsDbContext :
        BaseDbContext<NotificationsDbContext>
    {
        private const string DefaultSchemaName = "notifications";
        private const string NotificationStatusDbName = "NotificationStatus";

        static NotificationsDbContext()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<NotificationStatusDb>(
                pgName: $"{DefaultSchemaName}.{NotificationStatusDbName}",
                nameTranslator: new NpgsqlNullNameTranslator());
        }

        public NotificationsDbContext(
            IDbContextConfig config,
            ILifetimeScope lifetimeScope,
            ILogger logger,
            Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
            : base(config, lifetimeScope, logger, loggerFactory)
        {
        }

        public DbSet<NotificationDb> Notifications => Set<NotificationDb>();

        public override string SchemaName => DefaultSchemaName;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresEnum<NotificationStatusDb>(
                name: NotificationStatusDbName,
                nameTranslator: new NpgsqlNullNameTranslator());

            modelBuilder.Entity<NotificationDb>();
        }
    }
}