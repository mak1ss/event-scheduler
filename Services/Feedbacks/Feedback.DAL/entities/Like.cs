
using ADO_Dapper_ServiceManagment.DAL.interfaces.entities;

namespace ADO_Dapper_ServiceManagment.DAL.entities
{
    public class Like : IEntity<int>
    {
        public int Id { get; set; }

        public int FeedbackId { get; set; }

        public int UserId { get; set; }

        public DateTime? LikedAt { get; set; }
    }
}
