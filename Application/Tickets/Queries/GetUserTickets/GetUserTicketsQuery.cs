using Application.Tickets.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tickets.Queries.GetUserTickets
{
    public class GetUsersTicketsQuery : IRequest<IEnumerable<GetTicketResponse>>
    {
        public int UserId { get; set; }

        public class GetUsersTicketsQueryHandler : IRequestHandler<GetUsersTicketsQuery, IEnumerable<GetTicketResponse>>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;
            
            public GetUsersTicketsQueryHandler(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<GetTicketResponse>> Handle(GetUsersTicketsQuery request, CancellationToken cancellationToken)
            {
                // TODO: Request to UserAPI for validation?

                var tickets = await context.Tickets.Where(t => t.UserId == request.UserId).ToListAsync();

                return tickets.Select(mapper.Map<Ticket, GetTicketResponse>);
            }
        }
    }
}
