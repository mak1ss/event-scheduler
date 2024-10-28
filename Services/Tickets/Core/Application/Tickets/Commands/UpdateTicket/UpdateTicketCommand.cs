using Application.Common.Exceptions;
using Application.Tickets.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Tickets.Commands.Update
{
    public class UpdateTicketCommand : IRequest<TicketResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        public class UpdateTicketRequestHandler : IRequestHandler<UpdateTicketCommand, TicketResponse>
        {

            private readonly TicketDbContext context;
            private readonly IMapper mapper;

            public UpdateTicketRequestHandler(TicketDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<TicketResponse> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
            {
                var ticket = await context.Tickets.FindAsync(request.Id);

                if (ticket == null)
                {
                    throw new EntityNotFoundException($"Ticket with id {request.Id} doesn't exist");
                }

                ticket = mapper.Map<UpdateTicketCommand, Ticket>(request);

                await Task.Run(() => context.Tickets.Update(ticket));

                await context.SaveChangesAsync(cancellationToken);

                return mapper.Map<Ticket, TicketResponse>(ticket);
            }
        }


        private class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<UpdateTicketCommand, Ticket>();
            }
        }
    }
}
