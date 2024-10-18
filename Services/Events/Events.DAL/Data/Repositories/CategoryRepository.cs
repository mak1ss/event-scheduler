using Events.DAL.Entities;
using Events.DAL.Exceptions;
using Events.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Events.DAL.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EventContext context) : base(context) { }


        public override async Task<Category> GetCompleteEntityAsync(int id)
        {
            var category = await table.Include(c => c.Event).SingleOrDefaultAsync(c => c.Id == id);

            return category ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }
    }
}
