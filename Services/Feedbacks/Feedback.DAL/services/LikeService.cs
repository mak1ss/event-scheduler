using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services;
using ADO_Dapper_ServiceManagment.DAL.utils;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;


namespace ADO_Dapper_ServiceManagment.DAL.services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger logger;
        private readonly IMemoryCache cache;

        public LikeService(IUnitOfWork unitOfWork, IMemoryCache cache, ILogger<LikeService> logger) 
        {
            this.logger = logger;
            this.cache = cache;
            this.unitOfWork = unitOfWork;
        }

        public long Create(Like entity)
        {
            entity.LikedAt = DateTime.Now;
            var res = unitOfWork.LikeRepository.Add(entity);

            CacheHelper.Invalidate(cache, logger, $"feedback:{entity.Id}");
            return res;
        }

        public void Delete(Like entity)
        {
            unitOfWork.LikeRepository.Delete(entity);
            CacheHelper.Invalidate(cache, logger, $"feedback:{entity.Id}");
        }

        public IEnumerable<Like> GetAll()
        {
            return unitOfWork.LikeRepository.GetAll();
        }

        public Like GetById(int id)
        {
            return unitOfWork.LikeRepository.Get(id);
        }

        public void Update(Like entity)
        {
            unitOfWork.LikeRepository.Update(entity);
            CacheHelper.Invalidate(cache, logger, $"feedback:{entity.Id}");
        }
    }
}
