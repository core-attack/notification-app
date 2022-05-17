namespace NotificationApp.Mappers
{
    using Entities;
    using NotificationApp.Dal.Entities;

    public static class NotificationMapper
    {
        private const int DefaultPriority = 10;
        private const bool DefaultIsBackground = true;

        public static AndroidNotificationDalEntity Map(AndroidNotificationApiEntity source) =>
            new(source.DeviceToken, source.Message, source.Title, source.Condition);

        public static IOSNotificationDalEntity Map(IOSNotificationApiEntity source) =>
            new(source.PushToken, source.Alert, source.Priority ?? DefaultPriority, source.IsBackground ?? DefaultIsBackground);
    }
}
