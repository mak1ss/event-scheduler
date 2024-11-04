using Application.Protos;
using AutoMapper;
using Events.WEBAPI.Protos;
using Grpc.Core;
using Models.Events;
using Models.Tickets;
using PurchaseAggregator.gRPC.Eceptions;
using PurchaseAggregator.gRPC.Exceptions;
using PurchaseAggregator.gRPC.Models;

namespace PurchaseAggregator.gRPC.Service
{
    public class EventPurchaseService
    {

        private readonly EventProtoService.EventProtoServiceClient eventClient;
        private readonly PurchaseProtoService.PurchaseProtoServiceClient purchaseClient;
        private readonly IMapper mapper;

        public EventPurchaseService (EventProtoService.EventProtoServiceClient eventClient, PurchaseProtoService.PurchaseProtoServiceClient purchaseClient, IMapper mapper)
        {
            this.eventClient = eventClient;
            this.purchaseClient = purchaseClient;
            this.mapper = mapper;
        }

        public async Task<Purchase> CreatePurchase(DTO.CreatePurchaseRequest request)
        {
            decimal totalPrice = 0;

            Dictionary<int, Event> events = new Dictionary<int, Event>();

            Event current;
            try
            {
                foreach (var i in request.SelectedEvents)
                {

                    if (!events.TryGetValue(i.EventId, out current))
                    {
                        var reply = await eventClient.GetEventByIdAsync(new GetEventRequest { Id = i.EventId });
                        current = mapper.Map<EventGrpcResponse, Event>(reply);
                        events[i.EventId] = current;
                    }

                    totalPrice += events[i.EventId].Price * i.TicketsQuantity;
                }

                var grpcRequest = mapper.Map<DTO.CreatePurchaseRequest, CreatePurchaseRequest>(request);
                grpcRequest.TotalAmount = (double) totalPrice;

                var createPurchaseReply = await purchaseClient.CreatePurchaseAsync(grpcRequest);

                return mapper.Map<PurchaseResponse, Purchase>(createPurchaseReply);

            }
            catch (RpcException ex)
            {
                if (ex.Status.StatusCode.Equals(StatusCode.NotFound))
                {
                    throw new EntityNotFoundException(ex.Status.Detail);
                }
                if (ex.Status.StatusCode.Equals(StatusCode.InvalidArgument))
                {
                    throw new PromoCodeIsNotValidException(ex.Status.Detail);
                }
                throw;
            }
         
        }

        public async Task<EventPurchase> GetEventPurchase(int eventId)
        {
            try
            {
                var eventReply = await eventClient.GetEventByIdAsync(new GetEventRequest { Id = eventId });

                var ticketsReply = await purchaseClient.GetPurchasesByEventAsync(new GetPurchasesByEventRequest { EventId = eventId });

                return new EventPurchase
                {
                    Event = mapper.Map<EventGrpcResponse, Event>(eventReply),
                    purchasedTickets = mapper.Map<IEnumerable<PurchaseTicketResponse>, IEnumerable<Ticket>>(ticketsReply.Purchases)
                };
            }
            catch (RpcException ex)
            {
                if (ex.Status.StatusCode.Equals(StatusCode.NotFound))
                {
                    throw new EntityNotFoundException(ex.Status.Detail);
                }
                if (ex.Status.StatusCode.Equals(StatusCode.InvalidArgument))
                {
                    throw new PromoCodeIsNotValidException(ex.Status.Detail);
                }
                throw;
            }         
        }
    }
}
