using Promotions.gRPC.Entities;

namespace Promotions.gRPC.Interfaces.Repositories
{
    public interface IPromotionRepository
    {
        Task<Promotion> CreatePromo(Promotion promotion);
        Task<Promotion> UpdatePromo(Promotion promotion);
        Task<Promotion> GetPromoById(int id);
        Task<bool> DeletePromo(int id);
        Task<Promotion> GetPromoByCode(string code);
        Task<IEnumerable<Promotion>> GetAllPromos();
    }
}
