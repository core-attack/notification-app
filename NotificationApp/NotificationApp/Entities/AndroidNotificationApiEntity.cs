namespace NotificationApp.Entities
{
    public record AndroidNotificationApiEntity(string DeviceToken, string Message, string Title, string? Condition);
}