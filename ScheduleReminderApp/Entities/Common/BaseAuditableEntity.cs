using System;
namespace ScheduleReminderApp.Entities.Common
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

