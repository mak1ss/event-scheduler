using Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Tickets.Commands.Delete
{
    public class DeleteTicketCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
        {
            private readonly TicketDbContext context;

            public DeleteTicketCommandHandler(TicketDbContext context)
            {
                this.context = context;
            }

            public async Task Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
            {
                var ticket = await context.Tickets.FindAsync(request.Id);

                if (ticket == null)
                {
                    throw new EntityNotFoundException($"Ticket with id {request.Id} doesn't exist");
                }

                await Task.Run(() => context.Tickets.Remove(ticket));

                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
