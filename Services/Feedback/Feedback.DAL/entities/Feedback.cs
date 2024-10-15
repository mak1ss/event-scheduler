
using ADO_Dapper_ServiceManagment.DAL.interfaces.entities;

namespace ADO_Dapper_ServiceManagment.DAL.entities
{
    public class Feedback : IEntity<int>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Rating { get ; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        
        public int EventId { get; set; }
    }
}
