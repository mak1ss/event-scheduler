using Application.Protos;
using Application.Purchases.Commands.CreatePurchase;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace Application.Grpc
{
    public class GrpcMessagesProfile : Profile
    {

        public GrpcMessagesProfile()
        {
            CreateMap<CreatePurchaseRequest, CreatePurchaseCommand>()
                .ForMember(dest => dest.PromoCode, opt => opt.MapFrom(src => src.HasPromoCode ? src.PromoCode : null));

            CreateMap<Protos.CreatePurchaseTicket, Purchases.Commands.CreatePurchase.CreatePurchaseTicket>();

            CreateMap<Purchases.Dto.PurchaseResponse, Protos.PurchaseResponse>()
                .ForMember(dest => dest.PurchasedTime, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.PurchasedTime.ToUniversalTime())));

            CreateMap<Purchases.Dto.PurchaseTicketResponse, Protos.PurchaseTicketResponse>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.CreatedAt.ToUniversalTime())));
        }
    }
}
