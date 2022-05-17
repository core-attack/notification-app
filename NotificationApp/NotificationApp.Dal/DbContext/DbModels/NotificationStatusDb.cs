namespace NotificationApp.Dal.DbContext.DbModels
{
    public enum NotificationStatusDb
    {
        /// <summary>
        /// Newly created notification.
        /// </summary>
        NotSend,

        /// <summary>
        /// Notification provider confirmed Notification.
        /// </summary>
        Sent,

        /// <summary>
        /// Notification provider rejected notification.
        /// </summary>
        Failed,

        /// <summary>
        /// Sending was cancelled.
        /// </summary>
        Cancelled
    }
}