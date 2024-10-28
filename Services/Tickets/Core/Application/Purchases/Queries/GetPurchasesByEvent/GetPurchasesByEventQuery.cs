
using Application.Common.Exceptions;
using Application.Purchases.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace Application.Purchases.Queries.GetPurchasesByEvent
{
    public class GetPurchasesByEventQuery : IRequest<IEnumerable<PurchaseResponse>>
    {
        public int EventId { get; set; }

        public class GetPurchasesByEventQueryHandler : IRequestHandler<GetPurchasesByEventQuery, IEnumerable<PurchaseResponse>>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;

            public GetPurchasesByEventQueryHandler(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<PurchaseResponse>> Handle(GetPurchasesByEventQuery request, CancellationToken cancellationToken)
            {
                var purchases = await context.Purchases.Include(p => p.PurchasedTickets).Where(p => p.PurchasedTickets.Any(t => t.EventId == request.EventId)).ToListAsync();

                if (purchases.IsNullOrEmpty())
                {
                    throw new EntityNotFoundException($"Purchases with event {request.EventId} don't exist");
                }

                var purchaseResponses = purchases.Select(p => {
                    var pR = mapper.Map<Purchase, PurchaseResponse>(p);
                    pR.PurchasedTickets = p.PurchasedTickets.Select(t => mapper.Map<Ticket, PurchaseTicketResponse>(t)).ToList();
                    return pR;
                    }
                ).ToList();
               
                return purchaseResponses;
            }
        }
    }
}
