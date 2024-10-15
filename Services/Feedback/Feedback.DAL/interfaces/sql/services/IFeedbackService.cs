using ADO_Dapper_ServiceManagment.DAL.entities;

namespace ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services
{
    public interface IFeedbackService
    {
        long Create(Feedback entity);
        Feedback GetById(int id);

        void Update(Feedback entity);

        void Delete(Feedback entity);

        IEnumerable<Feedback> GetAll();
    }
}
