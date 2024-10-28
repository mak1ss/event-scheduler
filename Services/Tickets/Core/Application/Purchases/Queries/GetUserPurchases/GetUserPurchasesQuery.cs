using Application.Common.Exceptions;
using Application.Purchases.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace Application.Purchases.Queries.GetUserPurchases
{
    public class GetUserPurchasesQuery : IRequest<IEnumerable<PurchaseResponse>>
    {
        public int UserId { get; set; }

        public class GetUserPurchasesQueryHandler : IRequestHandler<GetUserPurchasesQuery, IEnumerable<PurchaseResponse>>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;

            public GetUserPurchasesQueryHandler(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<PurchaseResponse>> Handle(GetUserPurchasesQuery request, CancellationToken cancellationToken)
            {
                var purchases = await context.Purchases.Include(p => p.PurchasedTickets).Where(p => p.UserId == request.UserId).ToListAsync();

                if (purchases.IsNullOrEmpty())
                {
                    throw new EntityNotFoundException($"User with id {request.UserId} don't have any purchases");
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
