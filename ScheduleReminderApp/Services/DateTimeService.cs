﻿using System;
using ScheduleReminderApp.Repositories.Abstraction;

namespace ScheduleReminderApp.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

