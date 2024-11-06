using Bogus;
using Promotions.gRPC.Entities;
using Promotions.gRPC.Utils;

namespace Promotions.gRPC.Seeding
{
    public static class PromotionSeeder
    {
        public static List<Promotion> GeneratePromotions(int count)
        {
            var promotionFaker = new Faker<Promotion>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Code, f => PromocodeGenerator.GeneratePromoCode())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.DiscountPercentage, f => f.Random.Double(5, 50)) // Discount between 5% and 50%
                .RuleFor(p => p.StartDate, f => f.Date.Past(1))
                .RuleFor(p => p.EndDate, (f, p) => f.Date.Between(p.StartDate, p.StartDate.AddMonths(6)))
                .RuleFor(p => p.MaxUses, f => f.Random.Int(50, 1000)) // Maximum uses between 50 and 1000
                .RuleFor(p => p.TimesUsed, f => f.Random.Int(0, 50)); // Times used between 0 and 50

            return promotionFaker.Generate(count);
        }
    }
}
