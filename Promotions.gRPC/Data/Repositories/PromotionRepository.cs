using Microsoft.EntityFrameworkCore;
using Promotions.gRPC.Entities;
using Promotions.gRPC.Interfaces.Repositories;

namespace Promotions.gRPC.Data.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly PromotionContext ctx;
        private readonly DbSet<Promotion> table;

        public PromotionRepository(PromotionContext ctx)
        {
            this.ctx = ctx;
            table = ctx.Promotions;
        }

        public async Task<Promotion> CreatePromo(Promotion promotion)
        {
            await table.AddAsync(promotion);
            await ctx.SaveChangesAsync();
            return promotion;
        }

        public async Task<Promotion> GetPromoById(int id) => await table.FindAsync(id);

        public async Task<Promotion> GetPromoByCode(string code)
        {
            var entity = await table.Where(p => p.Code.Equals(code)).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IEnumerable<Promotion>> GetAllPromos()
        {
            var entities = await table.ToListAsync();
            return entities;
        }

        public async Task<Promotion> UpdatePromo(Promotion promotion)
        {
            await Task.Run(() => table.Update(promotion));
            await ctx.SaveChangesAsync();
            return promotion;
        }

        public async Task<bool> DeletePromo(int id)
        {
            var entity = await GetPromoById(id);
            await Task.Run(() => table.Remove(entity));
            var result = await ctx.SaveChangesAsync();

            return result > 0;
        }
         
    }
}
