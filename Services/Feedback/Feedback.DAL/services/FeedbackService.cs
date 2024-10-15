using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services;

namespace ADO_Dapper_ServiceManagment.DAL.services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork unitOfWork;

        public FeedbackService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public long Create(Feedback entity)
        {
            entity.CreatedAt = DateTime.Now;
            return unitOfWork.FeedbackRepository.Add(entity);
        }

        public void Delete(Feedback entity)
        {
            unitOfWork.FeedbackRepository.Delete(entity);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return unitOfWork.FeedbackRepository.GetAll();
        }

        public Feedback GetById(int id)
        {
            return unitOfWork.FeedbackRepository.Get(id);
        }

        public void Update(Feedback entity)
        {
            entity.UpdatedAt = DateTime.Now;
            unitOfWork.FeedbackRepository.Update(entity);
        }
    }
}
