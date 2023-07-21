﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ScheduleReminderApp.Entities.Common;
using ScheduleReminderApp.Repositories.Abstraction;

namespace ScheduleReminderApp.Interceptors
{

    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IDateTime _dateTime;

        public AuditableEntitySaveChangesInterceptor(IDateTime dateTime)
        {
            this._dateTime = dateTime;
        }


        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context == null) return;
            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = _dateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = _dateTime.Now;
                }
            }
        }
    }
}

