using System;
using Microsoft.EntityFrameworkCore;
using ScheduleReminderApp.Entities;
using ScheduleReminderApp.Interceptors;

namespace ScheduleReminderApp.DAL
{
    public class AppDbContext : DbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public AppDbContext(AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor,
            DbContextOptions<AppDbContext> options)
        : base(options)
        {
            this._auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public virtual DbSet<Reminder> Reminders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(this._auditableEntitySaveChangesInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

