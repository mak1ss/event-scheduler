using EF_ServiceManagement.BLL.DTO.Service;

namespace EF_ServiceManagement.BLL.Interfaces.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventResponse>> GetAsync();

        Task<EventResponse> GetByIdAsync(int id);

        Task InsertAsync(EventRequest request);

        Task UpdateAsync(EventRequest request);

        Task DeleteAsync(int id);

        Task<IEnumerable<EventResponse>> GetEventsByCategoryAsync(int categoryId);

        Task<IEnumerable<EventResponse>> GetEventsByTagsAsync(string[] tagNames);

        Task<EventResponse> AddTagAsync(int tagId, int serviceId);

        Task<EventResponse> DeleteTagAsync(int tagId, int serviceId);
    }
}
