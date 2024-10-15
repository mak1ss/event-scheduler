using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.repositories;
using Microsoft.Extensions.Configuration;

namespace ADO_Dapper_ServiceManagment.DAL.repositories.sql
{
    public class FeedbackRepository : GenericRepository<Feedback, int>, IFeedbackRepository
    {
        private static readonly string tableName = "Feedback";

        public FeedbackRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, tableName)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            connectionFactory.SetConnection(connectionString);
        }
    }
}
