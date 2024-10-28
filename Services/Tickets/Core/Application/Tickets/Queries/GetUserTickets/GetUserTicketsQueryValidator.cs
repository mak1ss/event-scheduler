
using FluentValidation;

namespace Application.Tickets.Queries.GetUserTickets
{
    public class GetUserTicketsQueryValidator : AbstractValidator<GetUsersTicketsQuery>
    {
        public GetUserTicketsQueryValidator() 
        {
            RuleFor(r => r.UserId).NotEmpty();
        }
    }
}
