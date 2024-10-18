using Events.BLL.DTO.Tag;

namespace Events.BLL.Interfaces.Services
{
    public interface ITagService
    {
        Task<IEnumerable<TagResponse>> GetAsync();

        Task<TagResponse> GetByIdAsync(int id);

        Task InsertAsync(TagRequest request);

        Task UpdateAsync(TagRequest request);

        Task DeleteAsync(int id);
    }
}
