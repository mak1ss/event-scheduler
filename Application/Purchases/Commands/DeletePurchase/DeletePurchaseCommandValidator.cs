
using FluentValidation;

namespace Application.Purchases.Commands.DeletePurchase
{
    public class DeletePurchaseCommandValidator : AbstractValidator<DeletePurchaseCommand>
    {
        public DeletePurchaseCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
