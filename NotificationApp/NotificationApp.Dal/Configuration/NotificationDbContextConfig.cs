namespace NotificationApp.Dal.Configuration
{
    using Core.Dal.Configuration;

    public class NotificationDbContextConfig : IDbContextConfig
    {
        public const string SectionName = "NotificationsDbContextConfig";

        public string ConnectionString { get; set; } = string.Empty;
    }
}