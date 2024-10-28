
using Application.Common.Exceptions;
using Application.Purchases.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Persistence;

namespace Application.Purchases.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommand : IRequest<PurchaseResponse>
    {
        public int Id { get; set; }
        public PurchaseStatus Status { get; set; }
        public string PaymentMethod { get; set; }
        public decimal? TotalAmount { get; set; }


        public class UpdatePurchaseCommandHanlder : IRequestHandler<UpdatePurchaseCommand, PurchaseResponse>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;

            public UpdatePurchaseCommandHanlder(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<PurchaseResponse> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
            {
                var purchase = await context.Purchases.FindAsync(request.Id);

                if (purchase == null)
                {
                    throw new EntityNotFoundException($"Purchase with id {request.Id} doesn't exist");
                }

                purchase.Status = request.Status;
                purchase.PaymentMethod = request.PaymentMethod;
                purchase.TotalAmount = request.TotalAmount;

                await Task.Run(() => context.Purchases.Update(purchase));

                await context.SaveChangesAsync();

                var purchaseResponse = mapper.Map<Purchase, PurchaseResponse>(purchase);
                purchaseResponse.PurchasedTickets = purchase.PurchasedTickets
                    .Select((t) => mapper.Map<Ticket, PurchaseTicketResponse>(t))
                    .ToList();

                return purchaseResponse;
            }
        }
    }
}
