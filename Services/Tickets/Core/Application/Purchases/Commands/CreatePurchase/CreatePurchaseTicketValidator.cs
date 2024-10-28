using FluentValidation;

namespace Application.Purchases.Commands.CreatePurchase
{
    public class CreatePurchaseTicketValidator : AbstractValidator<CreatePurchaseTicket>
    {
        public CreatePurchaseTicketValidator() 
        {
            RuleFor(t => t.EventId).NotEmpty();

            RuleFor(t => t.TicketsQuantity).NotEmpty();
        }
    }
}
