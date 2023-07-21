using System;
using ScheduleReminderApp.Entities;

namespace ScheduleReminderApp.Dtos
{
    public class CreateReminderDto
    {
        public string UserEmailAddress { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string MethodType { get; set; } 
        public DateTime SendAt { get; set; }
    }
}
