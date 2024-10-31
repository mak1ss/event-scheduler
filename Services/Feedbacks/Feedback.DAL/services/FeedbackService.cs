using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services;
using ADO_Dapper_ServiceManagment.DAL.utils;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace ADO_Dapper_ServiceManagment.DAL.services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<FeedbackService> logger;
        private readonly IMemoryCache cache;

        public FeedbackService(IUnitOfWork unitOfWork, IMemoryCache cache, ILogger<FeedbackService> logger)
        {
            this.cache = cache;
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public long Create(Feedback entity)
        {
            entity.CreatedAt = DateTime.Now;

            var res = unitOfWork.FeedbackRepository.Add(entity);
            string key = "feedbacks";
            CacheHelper.Invalidate(cache, logger, key);

            return res;
        }

        public void Delete(Feedback entity)
        {
            unitOfWork.FeedbackRepository.Delete(entity);

            CacheHelper.Invalidate(cache, logger, "feedbacks", $"feedback:{entity.Id}");
        }

        public IEnumerable<Feedback> GetAll()
        {
            string key = "feedbacks";
            var entities = CacheHelper.GetOrSet(key, unitOfWork.FeedbackRepository.GetAllFeedbacksWithLikes, 
                cache, logger);

            return entities;
        }

        public Feedback GetById(int id)
        {
            string key = $"feedback:{id}";
            var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15))
                    .SetPriority(CacheItemPriority.NeverRemove)
                    .SetSize(2048);

            var entity = CacheHelper.GetOrSet(key, () => unitOfWork.FeedbackRepository.GetFeedbackWithLikes(id), cache, logger, cacheOptions);
            return entity;   
        }

        public IEnumerable<Feedback> GetFeedbacksByEvent(int eventId)
        {
            return unitOfWork.FeedbackRepository.GetFeedbacksByEventId(eventId);
        }

        public void Update(Feedback entity)
        {
            entity.UpdatedAt = DateTime.Now;
            unitOfWork.FeedbackRepository.Update(entity);
        
            CacheHelper.Invalidate(cache, logger, "feedbacks", $"feedback:{entity.Id}");
        }
    }
}
