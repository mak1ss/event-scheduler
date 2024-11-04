using Application.Common.Exceptions;
using Application.Protos;
using Application.Purchases.Commands.CreatePurchase;
using Application.Tickets.Dto;
using Application.Tickets.Queries.GetTicketByEvent;
using AutoMapper;
using Grpc.Core;
using MediatR;

namespace Application.Grpc
{
    public class PurchaseService : PurchaseProtoService.PurchaseProtoServiceBase
    {

        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public PurchaseService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public override async Task<PurchaseResponse> CreatePurchase(CreatePurchaseRequest request, ServerCallContext context)
        {
            try
            {
                var purchase = await mediator.Send(mapper.Map<CreatePurchaseRequest, CreatePurchaseCommand>(request));

                return mapper.Map<Purchases.Dto.PurchaseResponse, PurchaseResponse>(purchase);
            }
            catch (Exception ex) when (ex is EntityNotFoundException || ex is PromoCodeIsNotValidException)
            {
                var status = ex is EntityNotFoundException ? StatusCode.NotFound : StatusCode.InvalidArgument;

                throw new RpcException(new Status(status, ex.Message));
            }
        }

        public override async Task<GetPurchasesByEventResponse> GetPurchasesByEvent(GetPurchasesByEventRequest request, ServerCallContext context)
        {
            try
            {
                var tickets = await mediator.Send(new GetTicketByEventQuery { EventId = request.EventId});
                var response = new GetPurchasesByEventResponse();
                response.Purchases.AddRange(mapper.Map<IEnumerable<TicketResponse>, IEnumerable<PurchaseTicketResponse>>(tickets));

                return response;
            }
            catch (EntityNotFoundException ex)
            {
                throw new RpcException(new Status(StatusCode.NotFound, ex.Message));
            }
        }
    }
}
