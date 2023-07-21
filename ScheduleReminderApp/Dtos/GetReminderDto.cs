using System;
namespace ScheduleReminderApp.Dtos
{
    public class GetReminderDto
    {
        public int Id { get; set; }
        public string UserEmailAddress { get; set; }
        public string Content { get; set; }
        public int MethodType { get; set; }
        public DateTime SendAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

