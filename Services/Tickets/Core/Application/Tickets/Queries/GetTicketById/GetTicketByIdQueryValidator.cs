using FluentValidation;

namespace Application.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdQueryValidator : AbstractValidator<GetTicketByIdQuery>
    {
        public GetTicketByIdQueryValidator() 
        {
            RuleFor(r => r.Id).NotEmpty();
        }    
    }
}
