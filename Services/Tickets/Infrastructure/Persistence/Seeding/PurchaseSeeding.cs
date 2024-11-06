using Bogus;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeding
{
    public class PurchaseSeeder
    {
        public static List<Purchase> GeneratePurchases(int count)
        {
            Console.WriteLine("Purchases seeding");
            var purchaseFaker = new Faker<Purchase>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.UserId, f => f.Random.Int(1, 20))
                .RuleFor(p => p.Status, f => f.PickRandom<PurchaseStatus>())
                .RuleFor(p => p.PaymentMethod, f => f.PickRandom(new[] { "Credit Card", "PayPal", "Bank Transfer" }))
                .RuleFor(p => p.PurchasedTime, f => f.Date.Past(1))
                .RuleFor(p => p.TotalAmount, f => f.Random.Decimal(20, 1000))
                .RuleFor(p => p.IsPromoCodeUsed, f => f.Random.Bool());

            return purchaseFaker.Generate(count);
        }

        public static List<Ticket> GenerateTickets(int count, List<Purchase> purchases)
        {
            var ticketFaker = new Faker<Ticket>()
                .RuleFor(t => t.Id, f => f.IndexFaker + 1)
                .RuleFor(t => t.EventId, f => f.Random.Int(1, 20))
                .RuleFor(t => t.UserId, f => f.Random.Int(1, 20))
                .RuleFor(t => t.CreatedAt, f => f.Date.Past(1))
                .RuleFor(t => t.PurchaseId, f => f.PickRandom(purchases).Id);

            return ticketFaker.Generate(count);
        }
    }
}
