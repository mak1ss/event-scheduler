using Events.DAL.Interfaces.Repositories;

namespace Events.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IEventRepository ServiceRepository { get; }
        ITagRepository TagRepository { get; }

        Task SaveChangesAsync();
    }
}
