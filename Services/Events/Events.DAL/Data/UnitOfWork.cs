

using Events.DAL.Interfaces;
using Events.DAL.Interfaces.Repositories;

namespace Events.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly EventContext context;

        public UnitOfWork(EventContext context, ICategoryRepository categoryRepository, 
            IEventRepository serviceRepository, ITagRepository tagRepository)
        {
            this.context = context;
            CategoryRepository = categoryRepository;
            ServiceRepository = serviceRepository;
            TagRepository = tagRepository;
        }

        public ICategoryRepository CategoryRepository { get; }
        public IEventRepository ServiceRepository { get; }
        public ITagRepository TagRepository { get; }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
