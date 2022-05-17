namespace NotificationApp.Dal.Entities
{
    public record AndroidNotificationDalEntity(string DeviceToken, string Message, string Title, string? Condition);
}