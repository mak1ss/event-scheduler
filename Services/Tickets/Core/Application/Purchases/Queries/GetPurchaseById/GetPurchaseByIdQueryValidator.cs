
using FluentValidation;

namespace Application.Purchases.Queries.GetPurchaseById
{
    public class GetPurchaseByIdQueryValidator : AbstractValidator<GetPurchaseByIdQuery>    
    {
        public GetPurchaseByIdQueryValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
