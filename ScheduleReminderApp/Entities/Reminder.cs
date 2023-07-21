using System;
using ScheduleReminderApp.Entities.Common;

namespace ScheduleReminderApp.Entities
{
    public class Reminder : BaseAuditableEntity
    {
        public string UserEmailAddress { get; set; }
        public MethodType Method { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
    }
}

