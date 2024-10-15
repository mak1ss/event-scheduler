using AutoMapper;
using EF_ServcieManagement.DAL.Entities;
using EF_ServcieManagement.DAL.Interfaces.Repositories;
using EF_ServcieManagement.DAL.Interfaces;
using EF_ServiceManagement.BLL.Interfaces.Services;
using EF_ServiceManagement.BLL.DTO.Service;

namespace EF_ServiceManagement.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEventRepository repo;

        public EventService(IUnitOfWork unit, IMapper mapper)
        {
            this.mapper = mapper;
            unitOfWork = unit;
            repo = unitOfWork.ServiceRepository;
        }

        public async Task<EventResponse> AddTagAsync(int tagId, int serviceId)
        {
            var service = await repo.GetByIdAsync(serviceId);
            var tag = await unitOfWork.TagRepository.GetByIdAsync(tagId);

            service.Tags.Add(tag);

            await repo.UpdateAsync(service);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<Event, EventResponse>(service);
        }

        public async Task DeleteAsync(int id)
        {
            await repo.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<EventResponse> DeleteTagAsync(int tagId, int serviceId)
        {
            var service = await repo.GetByIdAsync(serviceId);
            var tag = await unitOfWork.TagRepository.GetByIdAsync(tagId);

            service.Tags.Remove(tag);

            await repo.UpdateAsync(service);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<Event, EventResponse>(service);
        }

        public async Task<IEnumerable<EventResponse>> GetAsync()
        {
            var entities = await repo.GetAsync();
            return entities.Select(mapper.Map<Event, EventResponse>);
        }

        public async Task<EventResponse> GetByIdAsync(int id)
        {
            var entity = await repo.GetCompleteEntityAsync(id);
            return mapper.Map<Event, EventResponse>(entity);
        }

        public async Task<IEnumerable<EventResponse>> GetEventsByCategoryAsync(int categoryId)
        {
            var services = await repo.GetEventsByCategoryAsync(categoryId);
            return services.Select(mapper.Map<Event, EventResponse>);
        }

        public async Task<IEnumerable<EventResponse>> GetEventsByTagsAsync(string[] tagNames)
        {
            var services = await repo.GetEventsByTagsAsync(tagNames);
            return services.Select(mapper.Map<Event, EventResponse>);
        }

        public async Task InsertAsync(EventRequest request)
        {
            var service = mapper.Map<EventRequest, Event>(request);
            service.Tags = new List<Tag>(await unitOfWork.TagRepository.GetTagsByIds(request.TagIds));
            await repo.InsertAsync(service);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(EventRequest request)
        {
            var service = mapper.Map<EventRequest, Event>(request);
            service.Tags = new List<Tag>(await unitOfWork.TagRepository.GetTagsByIds(request.TagIds));
            await repo.UpdateAsync(service);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
