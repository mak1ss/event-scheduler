using Application.Protos;
using FluentValidation;

namespace PurchaseAggregator.gRPC.DTO
{
    public class CreatePurchaseRequest
    {
        public int UserId { get; set; }
        public PurchaseStatus Status { get; set; }
        public string PaymentMethod { get; set; }
        public IEnumerable<CreatePurchaseTicket> SelectedEvents { get; set; }
        public string? PromoCode { get; set; }
    }
    
    public class CreatePurchaseRequestValidator : AbstractValidator<CreatePurchaseRequest>
    {
        public CreatePurchaseRequestValidator()
        {
            RuleFor(r => r.UserId).NotNull();
            RuleFor(r => r.Status).NotNull();
            RuleFor(r => r.PaymentMethod).NotNull();
            RuleFor(r => r.SelectedEvents).NotEmpty();
            
        }
    }
}
