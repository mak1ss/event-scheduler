using Application.Tickets.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tickets.Queries.GetUserTickets
{
    public class GetUsersTicketsQuery : IRequest<IEnumerable<TicketResponse>>
    {
        public int UserId { get; set; }

        public class GetUsersTicketsQueryHandler : IRequestHandler<GetUsersTicketsQuery, IEnumerable<TicketResponse>>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;
            
            public GetUsersTicketsQueryHandler(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<TicketResponse>> Handle(GetUsersTicketsQuery request, CancellationToken cancellationToken)
            {
                // TODO: Request to UserAPI for validation?

                var tickets = await context.Tickets.Where(t => t.UserId == request.UserId).ToListAsync();

                return tickets.Select(mapper.Map<Ticket, TicketResponse>);
            }
        }
    }
}
