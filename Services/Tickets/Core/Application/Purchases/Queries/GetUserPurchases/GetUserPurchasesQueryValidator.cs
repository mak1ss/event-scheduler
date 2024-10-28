
using FluentValidation;

namespace Application.Purchases.Queries.GetUserPurchases
{
    public class GetUserPurchasesQueryValidator : AbstractValidator<GetUserPurchasesQuery>
    {
        public GetUserPurchasesQueryValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
        }
    }
}
