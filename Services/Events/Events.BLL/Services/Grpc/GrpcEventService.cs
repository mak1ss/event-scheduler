using AutoMapper;
using Events.BLL.DTO.Events;
using Events.BLL.Interfaces.Services;
using Events.DAL.Exceptions;
using Events.WEBAPI.Protos;
using Grpc.Core;

namespace Events.BLL.Services.Grpc
{
    public class GrpcEventService : EventProtoService.EventProtoServiceBase
    {
        private readonly IEventService service;
        private readonly IMapper mapper;

        public GrpcEventService(IEventService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public override async Task<EventGrpcResponse> GetEventById(GetEventRequest request, ServerCallContext context)
        {
            try
            {
                var entity = await service.GetByIdAsync(request.Id);

                return mapper.Map<EventResponse, EventGrpcResponse>(entity);

            } catch (EntityNotFoundException ex)
            {
                throw new RpcException(new Status(StatusCode.NotFound, ex.Message));
            }
        }
    }
}
