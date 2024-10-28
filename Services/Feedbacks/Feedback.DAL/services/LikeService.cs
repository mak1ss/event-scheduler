using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services;

namespace ADO_Dapper_ServiceManagment.DAL.services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork unitOfWork;

        public LikeService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public long Create(Like entity)
        {
            entity.LikedAt = DateTime.Now;
            return unitOfWork.LikeRepository.Add(entity);
        }

        public void Delete(Like entity)
        {
            unitOfWork.LikeRepository.Delete(entity);
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
        }
    }
}
