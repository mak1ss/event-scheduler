using Application.Common.Exceptions;
using Application.Purchases.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;
using Promotions.gRPC.Protos;

namespace Application.Purchases.Commands.CreatePurchase
{
    public class CreatePurchaseCommand : IRequest<PurchaseResponse>
    {
        public int UserId { get; set; }
        public PurchaseStatus Status { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
        public IEnumerable<CreatePurchaseTicket> SelectedEvents { get; set; }
        public string? PromoCode { get; set; }

        public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, PurchaseResponse>
        {
            private readonly TicketDbContext context;
            private readonly IMapper mapper;
            private readonly PromotionProtoService.PromotionProtoServiceClient promoClient;
            private readonly ILogger<CreatePurchaseCommandHandler> logger;

            public CreatePurchaseCommandHandler(TicketDbContext context, IMapper mapper, PromotionProtoService.PromotionProtoServiceClient promoClient,
                ILogger<CreatePurchaseCommandHandler> logger)
            {
                this.context = context;
                this.mapper = mapper;
                this.promoClient = promoClient;
                this.logger = logger;
            }

            public async Task<PurchaseResponse> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
            {
                PromoResponse promoReply = null;
                if (request.PromoCode != null)
                {
                   promoReply = await UsePromoCode(request);
                }

                var purchase = mapper.Map<CreatePurchaseCommand, Purchase>(request);

                purchase.PurchasedTime = DateTime.UtcNow;

                var tickets = new List<Ticket>();

                foreach (var purchaseTicket in request.SelectedEvents)
                {
                    for (int i = 0; i < purchaseTicket.TicketsQuantity; i++)
                    {
                        tickets.Add(new Ticket
                        {
                            UserId = purchase.UserId,
                            EventId = purchaseTicket.EventId,
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }

                purchase.PurchasedTickets = tickets;

                await context.Purchases.AddAsync(purchase, cancellationToken);

                await context.SaveChangesAsync();

                var purchaseResponse = mapper.Map<Purchase, PurchaseResponse>(purchase);

                purchaseResponse.PurchasedTickets = purchase.PurchasedTickets
                    .Select((t) => mapper.Map<Ticket, PurchaseTicketResponse>(t))
                    .ToList();

                purchaseResponse.IsPromoCodeUsed = promoReply != null;

                return purchaseResponse;
            }

            private async Task<PromoResponse> UsePromoCode(CreatePurchaseCommand purchase)
            {
                try
                {
                    var reply = await promoClient.UsePromoAsync(new UsePromoRequest { Code = purchase.PromoCode });

                    logger.LogInformation($"Used Promocode {reply.Code} with discount {reply.DiscountPercentage}%; -> {reply.Description}." +
                        $" Uses left: {reply.MaxUses - reply.TimesUsed}.");

                    purchase.TotalAmount -= purchase.TotalAmount * ((decimal)reply.DiscountPercentage / 100);

                    return reply;

                } catch (RpcException ex)
                {
                    if(ex.Status.StatusCode.Equals(StatusCode.InvalidArgument))
                    {
                        throw new PromoCodeIsNotValidException(ex.Status.Detail);
                    }
                    if(ex.Status.StatusCode.Equals(StatusCode.NotFound))
                    {
                        throw new EntityNotFoundException(ex.Status.Detail);
                    }
                }

                return null;
            }
        }

        private class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<CreatePurchaseCommand, Purchase>();
            }
        }
    }
}
