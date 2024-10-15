using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.repositories;
using Microsoft.Extensions.Configuration;

namespace ADO_Dapper_ServiceManagment.DAL.repositories.sql
{
    public class LikeRepotisory : GenericRepository<Like, int>, ILikeRepository
    {
        private static readonly string tableName = "Likes";

        public LikeRepotisory(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, tableName)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            connectionFactory.SetConnection(connectionString);
        }
    }
}
