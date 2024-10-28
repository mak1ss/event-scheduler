
using FluentValidation;

namespace Application.Purchases.Queries.GetPurchasesByEvent
{
    public class GetPurchasesByEventQueryValidator : AbstractValidator<GetPurchasesByEventQuery>
    {
        public GetPurchasesByEventQueryValidator()
        {
            RuleFor(r => r.EventId).NotEmpty();
        }
    }
}
