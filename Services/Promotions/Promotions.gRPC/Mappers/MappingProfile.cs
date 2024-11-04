using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Promotions.gRPC.Entities;
using Promotions.gRPC.Protos;

namespace Promotions.gRPC.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Promotion, PromoResponse>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.StartDate.ToUniversalTime())))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.EndDate.ToUniversalTime())));

            CreateMap<CreatePromoRequest, Promotion>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToDateTime()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToDateTime()));

            CreateMap<UpdatePromoRequest, Promotion>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToDateTime()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToDateTime()));

        }
    }
}
