using System;
namespace ScheduleReminderApp.Repositories.Abstraction
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}

