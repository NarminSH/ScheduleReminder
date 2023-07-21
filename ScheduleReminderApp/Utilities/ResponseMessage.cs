using System;
using System.Net;

namespace ScheduleReminderApp.Utilities
{
    public class ResponseMessage
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
}

