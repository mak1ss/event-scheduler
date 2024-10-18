using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.repositories;

namespace ADO_Dapper_ServiceManagment.DAL.unitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly ILikeRepository likeRepository;

        public UnitOfWork(IFeedbackRepository feedbackRepository, ILikeRepository likeRepository)
        {
            this.feedbackRepository = feedbackRepository;
            this.likeRepository = likeRepository;
        }

        public IFeedbackRepository FeedbackRepository { get { return feedbackRepository; } }
        public ILikeRepository LikeRepository { get { return likeRepository; } }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
