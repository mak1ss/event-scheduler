
using FluentValidation;

namespace Application.Tickets.Commands.Update
{
    public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
    {
        public UpdateTicketCommandValidator() 
        {
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.EventId).NotEmpty();
        }
    }
}
