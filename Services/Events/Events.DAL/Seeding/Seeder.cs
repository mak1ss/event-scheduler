using Bogus;
using Events.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.DAL.Seeding
{
    public class Seeder
    {
        public static IEnumerable<Category> GenerateCategories(int count)
        {
            var categoryFaker = new Faker<Category>()
                .RuleFor(c => c.Id, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0])
                .RuleFor(c => c.Description, f => f.Lorem.Sentence())
                .RuleFor(c => c.CreatedAt, f => f.Date.Past(1))
                .RuleFor(c => c.UpdatedAt, f => f.Date.Recent());

            return categoryFaker.Generate(count);
        }

        public static IEnumerable<Tag> GenerateTags(int count)
        {
            var tagFaker = new Faker<Tag>()
                .RuleFor(t => t.Id, f => f.IndexFaker + 1)
                .RuleFor(t => t.Name, f => f.Commerce.ProductMaterial())
                .RuleFor(t => t.CreatedAt, f => f.Date.Past(1))
                .RuleFor(t => t.UpdatedAt, f => f.Date.Recent());

            return tagFaker.Generate(count);
        }

        public static IEnumerable<Event> GenerateEvents(int count, List<Category> categories)
        {
            var eventFaker = new Faker<Event>()
                .RuleFor(e => e.Id, f => f.IndexFaker + 1)
                .RuleFor(e => e.Name, f => f.Commerce.ProductName())
                .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
                .RuleFor(e => e.Price, f => f.Random.Decimal(10, 500))
                .RuleFor(e => e.CreatedAt, f => f.Date.Past(1))
                .RuleFor(e => e.UpdatedAt, f => f.Date.Recent())
                .RuleFor(e => e.CategoryId, f => f.PickRandom(categories).Id);

            return eventFaker.Generate(count);
        }
    }
}
