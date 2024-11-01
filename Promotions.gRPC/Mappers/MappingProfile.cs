using AutoMapper;
using Promotions.gRPC.Entities;
using Promotions.gRPC.Protos;

namespace Promotions.gRPC.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Promotion, PromoResponse>();
            CreateMap<CreatePromoRequest, Promotion>();
            CreateMap<UpdatePromoRequest, Promotion>();

        }
    }
}
