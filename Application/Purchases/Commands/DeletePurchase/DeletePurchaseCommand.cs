
using Application.Common.Exceptions;
using MediatR;
using Persistence;

namespace Application.Purchases.Commands.DeletePurchase
{
    public class DeletePurchaseCommand : IRequest
    {
        public int Id { get; set; }

        public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand>
        {
            private readonly TicketDbContext context;

            public DeletePurchaseCommandHandler(TicketDbContext context)
            {
                this.context = context;
            }

            public async Task Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
            {
                var purchase = await context.Purchases.FindAsync(request.Id);

                if(purchase == null)
                {
                    throw new EntityNotFoundException($"Purchase with id {request.Id} doesn't exist");
                }

                await Task.Run(() => { context.Purchases.Remove(purchase); });

                await context.SaveChangesAsync();
            }
        }
    }
}
