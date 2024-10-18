using Events.DAL.Entities;

namespace Events.DAL.Interfaces.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<IEnumerable<Tag>> GetTagsByIds(int[] ids);
    }
}
