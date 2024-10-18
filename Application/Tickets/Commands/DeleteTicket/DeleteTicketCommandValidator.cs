using Application.Tickets.Commands.Delete;
using FluentValidation;

namespace Application.Tickets.Commands.DeleteTicket
{
    public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
    {
        public DeleteTicketCommandValidator() 
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
