
using Application.Common.Exceptions;
using Application.Tickets.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdQuery : IRequest<GetTicketResponse>
    {
        public int Id { get; set; }

        public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, GetTicketResponse>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;

            public GetTicketByIdQueryHandler(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<GetTicketResponse> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
            {
                var ticket = await context.Tickets.FindAsync(request.Id);

                if (ticket == null)
                {
                    throw new EntityNotFoundException($"Ticket with id {request.Id} doesn't exist");
                }

                return mapper.Map<Ticket, GetTicketResponse>(ticket);
            }
        }
    }
}
