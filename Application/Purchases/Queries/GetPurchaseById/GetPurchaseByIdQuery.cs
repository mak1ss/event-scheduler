
using Application.Common.Exceptions;
using Application.Purchases.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Purchases.Queries.GetPurchaseById
{
    public class GetPurchaseByIdQuery : IRequest<PurchaseResponse>
    {
        public int Id { get; set; }

        public class GetPurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, PurchaseResponse>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;

            public GetPurchaseByIdQueryHandler(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<PurchaseResponse> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
            {
                var purchase = await context.Purchases.Include(p => p.PurchasedTickets).SingleOrDefaultAsync(p => p.Id == request.Id);

                if (purchase == null)
                {
                    throw new EntityNotFoundException($"Purchase with id {request.Id} doesn't exist");
                }

                var purchaseResponse = mapper.Map<Purchase, PurchaseResponse>(purchase);
                purchaseResponse.PurchasedTickets = purchase.PurchasedTickets
                    .Select((t) => mapper.Map<Ticket, PurchaseTicketResponse>(t))
                    .ToList();

                return purchaseResponse;
            }
        }
    }
}
