namespace NotificationApp.Entities
{
    public record IOSNotificationApiEntity(string PushToken, string Alert, int? Priority, bool? IsBackground);
}