using FluentValidation;
using Promotions.gRPC.Protos;

namespace Promotions.gRPC.Validations
{
    public class UpdatePromoRequestValidator : AbstractValidator<UpdatePromoRequest>
    {
        public UpdatePromoRequestValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be a positive integer.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code must not be empty.")
                .Length(1, 100).WithMessage("Code must be between 1 and 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description must not be empty.")
                .Length(1, 500).WithMessage("Description must be between 1 and 500 characters.");

            RuleFor(x => x.DiscountPercentage)
                .InclusiveBetween(0, 100).WithMessage("DiscountPercentage must be between 0 and 100.");

            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("StartDate must be provided.");

            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("EndDate must be provided.")
                .Must((promo, endDate) =>
                {
                    if (promo.StartDate == null || endDate == null)
                    {
                        return false;
                    }

                    var startDateTime = promo.StartDate.ToDateTime();
                    var endDateTime = endDate.ToDateTime();

                    return endDateTime >= startDateTime;
                })
                .WithMessage("EndDate must be greater than or equal to StartDate.");

            RuleFor(x => x.MaxUses)
                .GreaterThanOrEqualTo(0).WithMessage("MaxUses must be a non-negative integer.");

            RuleFor(x => x.EventId)
            .GreaterThan(0).WithMessage("EventId must be a positive integer.");
        }
    }
}
