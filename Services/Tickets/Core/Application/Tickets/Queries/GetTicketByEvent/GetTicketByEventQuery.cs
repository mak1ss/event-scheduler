using Application.Common.Exceptions;
using Application.Tickets.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Queries.GetTicketByEvent
{
    public class GetTicketByEventQuery : IRequest<IEnumerable<TicketResponse>>
    {
        public int EventId { get; set; }

        public class GetTicketByEventQueryHandler : IRequestHandler<GetTicketByEventQuery, IEnumerable<TicketResponse>>
        {
            public readonly TicketDbContext ctx;
            public readonly IMapper mapper;

            public GetTicketByEventQueryHandler(TicketDbContext ctx, IMapper mapper)
            {
                this.ctx = ctx;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<TicketResponse>> Handle(GetTicketByEventQuery request, CancellationToken cancellationToken)
            {
                var tickets = await ctx.Tickets.Where(t => t.EventId == request.EventId).ToListAsync();

                if(!tickets.Any())
                {
                    throw new EntityNotFoundException($"There is no purchased tickets for event with id {request.EventId}");
                }

                return mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketResponse>>(tickets);
            }
        }
    }
}
