
using FluentValidation;

namespace Application.Purchases.Commands.CreatePurchase
{
    public class CreatePurchaseCommandValidator : AbstractValidator<CreatePurchaseCommand>
    {
        public CreatePurchaseCommandValidator() 
        {
            RuleFor(p => p.UserId)
                .NotEmpty();

            RuleFor(p => p.PaymentMethod)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage(p => $"{nameof(p.PaymentMethod)} length should be less than 100 symbols");

            RuleFor(p => p.Status)
                .NotEmpty();

            RuleFor(p => p.TotalAmount)
                .NotEmpty();

            RuleFor(p => p.SelectedEvents)
                .NotNull();
        }
    }
}
