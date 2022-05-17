namespace Core.Dal.DbContext
{
    using Microsoft.EntityFrameworkCore;

    public static class DbContextHelper
    {
        private const string MigrationsHistoryTable = "__EFMigrationsHistory";

        /// <summary>
        /// Standard method for configuring db context.
        /// </summary>
        /// <param name="ctx">context.</param>
        /// <param name="optionsBuilder">DbContextOptionsBuilder.</param>
        public static void OnConfiguringImplementation(this IBaseDbContext ctx, DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                ctx.ConnectionString,
                opt => opt.MigrationsHistoryTable(MigrationsHistoryTable, ctx.MigrationsHistorySchemaName));

            optionsBuilder.UseLoggerFactory(ctx.LoggerFactory);
        }

        public static void OnModelCreatingImplementation(this IBaseDbContext ctx, ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(ctx.SchemaName);
        }
    }
}
