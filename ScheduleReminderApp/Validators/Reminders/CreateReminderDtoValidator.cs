using System;
using FluentValidation;
using ScheduleReminderApp.Dtos;

namespace ScheduleReminderApp.Validators.Reminders
{
    public class CreateReminderDtoValidator : AbstractValidator<CreateReminderDto>
    {
        public CreateReminderDtoValidator()
        {
            RuleFor(r => r.UserEmailAddress)
                .NotEmpty().WithMessage("Please provide email address")
                .NotNull().WithMessage("Please provide email address")
                .EmailAddress().WithMessage("A valid email address is required");
            RuleFor(r => r.Content)
                .NotEmpty().WithMessage("Please write content")
                .NotNull().WithMessage("Please write content");
            RuleFor(r => r.SendAt)
                .NotEmpty().WithMessage("Time is required")
                .GreaterThan(r => DateTime.Now).WithMessage("Please enter valid date");
        }
    }
}

