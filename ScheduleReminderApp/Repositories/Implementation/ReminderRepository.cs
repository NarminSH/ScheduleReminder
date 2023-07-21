using System;
using Microsoft.EntityFrameworkCore;
using ScheduleReminderApp.DAL;
using ScheduleReminderApp.Dtos;
using ScheduleReminderApp.Entities;
using ScheduleReminderApp.Repositories.Abstraction;
using ScheduleReminderApp.Utilities.Exceptions;

namespace ScheduleReminderApp.Repositories.Implementation
{
    public class ReminderRepository : GenericRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(AppDbContext context) : base(context)
        {
        }
    }
}

