using Application.Protos;
using AutoMapper;
using Events.WEBAPI.Protos;
using Models.Events;
using Models.Tickets;

namespace PurchaseAggregator.gRPC.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DTO.CreatePurchaseRequest, CreatePurchaseRequest>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });

            CreateMap<EventGrpcResponse, Event>();
            CreateMap<CategoryGrpcResponse, Category>();
            CreateMap<TagGrpcResponse, Tag>();

            CreateMap<PurchaseResponse, Purchase>()
                .ForMember(dest => dest.PurchasedTime, opt => opt.MapFrom(src => src.PurchasedTime.ToDateTime()));
            CreateMap<PurchaseTicketResponse, Ticket>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToDateTime())); ;
        }
    }
}
