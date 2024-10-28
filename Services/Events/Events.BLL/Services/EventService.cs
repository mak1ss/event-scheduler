using AutoMapper;
using Events.DAL.Entities;
using Events.DAL.Interfaces.Repositories;
using Events.DAL.Interfaces;
using Events.BLL.Interfaces.Services;
using Events.BLL.DTO.Events;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Events.BLL.Utils;

namespace Events.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEventRepository repo;
        private readonly IDistributedCache cache;
        private readonly ILogger logger;   
        public EventService(IUnitOfWork unit, IMapper mapper, IDistributedCache cache, ILogger<EventService> logger)
        {
            this.mapper = mapper;
            unitOfWork = unit;
            repo = unitOfWork.ServiceRepository;
            this.cache = cache;
            this.logger = logger;
        }

        public async Task<EventResponse> AddTagAsync(int tagId, int eventId)
        {
            var @event = await repo.GetByIdAsync(eventId);
            var tag = await unitOfWork.TagRepository.GetByIdAsync(tagId);

            @event.Tags.Add(tag);

            await repo.UpdateAsync(@event);
            await unitOfWork.SaveChangesAsync();
            cache.Invalidate(logger, "events", $"event:{eventId}");
            return mapper.Map<Event, EventResponse>(@event);
        }

        public async Task DeleteAsync(int id)
        {
            await repo.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
            cache.Invalidate(logger, "events", $"event:{id}");
        }

        public async Task<EventResponse> DeleteTagAsync(int tagId, int eventId)
        {
            var service = await repo.GetByIdAsync(eventId);
            var tag = await unitOfWork.TagRepository.GetByIdAsync(tagId);

            service.Tags.Remove(tag);

            await repo.UpdateAsync(service);
            await unitOfWork.SaveChangesAsync();
            cache.Invalidate(logger, "events", $"event:{eventId}");
            return mapper.Map<Event, EventResponse>(service);
        }

        public async Task<IEnumerable<EventResponse>> GetAsync()
        {
            var entities = await cache.GetOrSetAsyn("events", repo.GetAsync, logger);
            return entities.Select(mapper.Map<Event, EventResponse>);
        }

        public async Task<EventResponse> GetByIdAsync(int id)
        {
            var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
            var entity = await cache.GetOrSetAsyn($"event:{id}", () => repo.GetCompleteEntityAsync(id), logger);
            return mapper.Map<Event, EventResponse>(entity);
        }

        public async Task<IEnumerable<EventResponse>> GetEventsByCategoryAsync(int categoryId)
        {
            var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
            var events = await cache.GetOrSetAsyn($"eventsByCategory:{categoryId}", () => repo.GetEventsByCategoryAsync(categoryId), logger, options);
            return events.Select(mapper.Map<Event, EventResponse>);
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
            cache.Invalidate(logger, "events", $"eventsByCategory:{service.CategoryId}");
        }

        public async Task UpdateAsync(EventRequest request)
        {
            var service = mapper.Map<EventRequest, Event>(request);
            service.Tags = new List<Tag>(await unitOfWork.TagRepository.GetTagsByIds(request.TagIds));
            await repo.UpdateAsync(service);
            await unitOfWork.SaveChangesAsync();
            cache.Invalidate(logger, "events", $"event:{service.Id}");
        }
    }
}
