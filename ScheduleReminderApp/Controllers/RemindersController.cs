using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleReminderApp.Dtos;
using ScheduleReminderApp.Entities;
using ScheduleReminderApp.Repositories.Abstraction;
using ScheduleReminderApp.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScheduleReminderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : Controller
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IMapper _mapper;
        public RemindersController(IReminderRepository reminderRepository, IMapper mapper)
        {
            _reminderRepository = reminderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<GenericResponseMessage<IEnumerable<GetReminderDto>>> GetAllReminders()
        {
            IEnumerable<Reminder> reminders = await _reminderRepository.GetAllAsync();
            var remiderDtos = _mapper.Map<IEnumerable<GetReminderDto>>(reminders);
            return new GenericResponseMessage<IEnumerable<GetReminderDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = remiderDtos
            };
        }
        [HttpPost]
        public async Task<ResponseMessage> CreateReminder([FromBody] CreateReminderDto createReminderDto)
        {
            Reminder newReminder = _mapper.Map<Reminder>(createReminderDto);
            if (createReminderDto.MethodType != "Telegram" && createReminderDto.MethodType != "Email" )
            {
                return new ResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Method type can be either Telegram or Email"
                };
            }
            //todo add enum automapper
            if (createReminderDto.MethodType == "Telegram") { newReminder.Method = MethodType.Telegram;}
            else if(createReminderDto.MethodType == "Email") { newReminder.Method = MethodType.Email; }
            bool result = await _reminderRepository.AddAsync(newReminder);
            if (result)
            {
                return new ResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Message = "Your reminder is successfully created!"
                };
            }

            return new ResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "There was a problem saving your reminder"
            };
        }


        [HttpPut("{id}")]
        public async Task<ResponseMessage> Update(int id, CreateReminderDto createReminderDto)
        {
            var item = await _reminderRepository.GetByIdAsync(id);
            Reminder updatedReminder = _mapper.Map<Reminder>(createReminderDto);
            updatedReminder.Id = item.Id;
            bool result = await _reminderRepository.UpdateAsync(updatedReminder);
            if (result)
            {
                return new ResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Message = "Your reminder is successfully updated!"
                };
            }

            return new ResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "There was a problem updating your reminder"
            };
        }
        [HttpDelete("{id}")]
        public async Task<ResponseMessage> Delete(int id)
        {
            bool result = await _reminderRepository.Delete(id);
            if (result)
            {
                return new ResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Message = "Reminder is successfully deleted!"
                };
            }

            return new ResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "There was a problem deleting reminder"
            };
        }
    }

}

