using System;
using System.Net;

namespace ScheduleReminderApp.Utilities
{
    public class GenericResponseMessage<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}

