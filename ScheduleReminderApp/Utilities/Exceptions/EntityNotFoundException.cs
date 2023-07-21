﻿using System;
namespace ScheduleReminderApp.Utilities.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
           
        }
        public EntityNotFoundException() : base("Entity was not found")
        {

        }
    }
} 

