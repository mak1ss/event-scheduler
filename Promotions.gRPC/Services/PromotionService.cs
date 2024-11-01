using AutoMapper;
using Grpc.Core;
using Promotions.gRPC.Entities;
using Promotions.gRPC.Interfaces.Repositories;
using Promotions.gRPC.Protos;
using Promotions.gRPC.Utils;

namespace Promotions.gRPC.Services
{
    public class PromotionService : PromotionProtoService.PromotionProtoServiceBase
    {
        private readonly IPromotionRepository repo;
        private readonly IMapper mapper;

        public PromotionService(IPromotionRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        public override async Task<PromoResponse> CreatePromo(CreatePromoRequest request, ServerCallContext context)
        {
            var promo = mapper.Map<CreatePromoRequest, Promotion>(request);
            promo.Code = PromocodeGenerator.GeneratePromoCode();
            promo = await repo.CreatePromo(promo);

            return mapper.Map<Promotion, PromoResponse>(promo);
        }

        public override async Task<DeletePromoResponse> DeletePromo(DeletePromoRequest request, ServerCallContext context)
        {
            var promo = await repo.GetPromoById(request.Id);
            if(promo == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Promotion with id {request.Id} doesn't exist."));
            }
            bool result = await repo.DeletePromo(promo.Id);
            
            return new DeletePromoResponse
            {
                Success = result
            };
        }

        public override async Task<PromoResponse> UpdatePromo(UpdatePromoRequest request, ServerCallContext context)
        {
            var promo = await repo.GetPromoById(request.Id);
            if (promo == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Promotion with id {request.Id} doesn't exist."));
            }
            promo = mapper.Map(request, promo);
            promo = await repo.UpdatePromo(promo);

            return mapper.Map<Promotion, PromoResponse>(promo);
        }

        public override async Task<PromoResponse> UsePromo(UsePromoRequest request, ServerCallContext context)
        {
            var promo = await repo.GetPromoByCode(request.Code);
            if(promo == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Promotion with code {request.Code} doesn't exist."));
            }

            if(!(promo.EndDate >= DateTime.UtcNow || promo.TimesUsed < promo.MaxUses))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"Promotion with code {request.Code} either expired or exceeded its use limit"));
            }

            promo.TimesUsed++;
            await repo.UpdatePromo(promo);

            return mapper.Map<Promotion, PromoResponse>(promo);
        }

        public override async Task<PromoResponseList> GetPromosByEvent(GetPromosByEventRequest request, ServerCallContext context)
        {
            var promos = await repo.GetPromosByEvent(request.EventId);
            if (promos == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"There is no promotions for event with id {request.EventId}"));
            }

            promos = promos.Where(p => p.EndDate >= DateTime.UtcNow && p.TimesUsed < p.MaxUses);

            var response = new PromoResponseList();
            response.Items.AddRange(mapper.Map<IEnumerable<Promotion>, IEnumerable<PromoResponse>>(promos));

            return response;
        }
    }

}
