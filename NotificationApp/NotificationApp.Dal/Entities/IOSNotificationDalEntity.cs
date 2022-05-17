namespace NotificationApp.Dal.Entities
{
    public record IOSNotificationDalEntity(string PushToken, string Alert, int Priority, bool IsBackground);
}