
using FluentValidation;

namespace Application.Purchases.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommandValidator : AbstractValidator<UpdatePurchaseCommand>
    {
        public UpdatePurchaseCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.Status).NotEmpty();

            RuleFor(p => p.PaymentMethod)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage(p => $"{nameof(p.PaymentMethod)} length should be less than 100 symbols");

        }
    }
}
