namespace NotificationApp.Dal.DbContext.DbModels
{
    using System;
    using Core.Dal.DbContext.DbModels;

    public class NotificationDb : BaseEntityDb
    {
        [Obsolete("Automatic convert only", error: true)]
        public NotificationDb()
        {
        }

        public NotificationDb(NotificationStatusDb status, string payload)
        {
            Status = status;
            Payload = payload;
        }

        public NotificationStatusDb Status { get; set; }

        public string Payload { get; set; }
    }
}