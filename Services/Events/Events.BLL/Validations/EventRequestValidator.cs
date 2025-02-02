﻿
using Events.BLL.DTO.Events;
using FluentValidation;

namespace Events.BLL.Validations
{
    public class EventRequestValidator : AbstractValidator<EventRequest>
    {
        public EventRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Name)} can't be empty")
                .MaximumLength(50)
                .WithMessage(request => $"{nameof(request.Name)} length should be less than 50 symbols");

            RuleFor(request => request.Description)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Description)} can't be empty")
                .MaximumLength(1000)
                .WithMessage(request => $"{nameof(request.Description)} length should be less than 1000 symbols");

            RuleFor(request => request.Price)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.Price)} can't be empty");
        }
    }
}
