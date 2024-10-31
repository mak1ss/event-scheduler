
using ADO_Dapper_ServiceManagment.DAL.entities;

namespace ADO_Dapper_ServiceManagment.DAL.interfaces.sql.repositories
{
    public interface IFeedbackRepository : IGenericRepository<Feedback,int>
    {
        IEnumerable<Feedback> GetAllFeedbacksWithLikes();

        Feedback GetFeedbackWithLikes(int id);

        IEnumerable<Feedback> GetFeedbacksByEventId(int eventId);
    }
}
