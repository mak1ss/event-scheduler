using Application.Purchases.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Persistence;

namespace Application.Purchases.Commands.CreatePurchase
{
    public class CreatePurchaseCommand : IRequest<PurchaseResponse>
    {
        public int UserId { get; set; }
        public PurchaseStatus Status { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
        public IEnumerable<CreatePurchaseTicket> SelectedEvents { get; set; }

        public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, PurchaseResponse>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;

            public CreatePurchaseCommandHandler(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<PurchaseResponse> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
            {
                // TODO : Request to EventAPI and UserAPI for validation?
                var purchase = mapper.Map<CreatePurchaseCommand, Purchase>(request);
                purchase.PurchasedTime = DateTime.UtcNow;

                var tickets = new List<Ticket>();

                foreach (var purchaseTicket in request.SelectedEvents)
                {
                    for (int i = 0; i < purchaseTicket.TicketsQuantity; i++)
                    {
                        tickets.Add(new Ticket
                        {
                            UserId = purchase.UserId,
                            EventId = purchaseTicket.EventId,
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }

                purchase.PurchasedTickets = tickets;

                await context.Purchases.AddAsync(purchase, cancellationToken);

                await context.SaveChangesAsync();

                var purchaseResponse = mapper.Map<Purchase, PurchaseResponse>(purchase);
                purchaseResponse.PurchasedTickets = purchase.PurchasedTickets
                    .Select((t) => mapper.Map<Ticket, PurchaseTicketResponse>(t))
                    .ToList();

                return purchaseResponse;
            }
        }

        private class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<CreatePurchaseCommand, Purchase>();
            }
        }
    }
}
