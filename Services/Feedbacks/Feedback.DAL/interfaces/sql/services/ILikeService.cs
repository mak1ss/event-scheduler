

using ADO_Dapper_ServiceManagment.DAL.entities;

namespace ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services
{
    public interface ILikeService
    {
        long Create(Like entity);
        Like GetById(int id);

        void Update(Like entity);

        void Delete(Like entity);

        IEnumerable<Like> GetAll();
    }
}
