using System;
using AutoMapper;
using ScheduleReminderApp.Dtos;
using ScheduleReminderApp.Entities;

namespace ScheduleReminderApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reminder, GetReminderDto>().ReverseMap();
            CreateMap<CreateReminderDto, Reminder>();
        }
    }
}

