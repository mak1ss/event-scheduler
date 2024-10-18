
namespace ADO_Dapper_ServiceManagment.DAL.dtos.feedback
{
    public class FeedbackResponse
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int EventId { get; set; }
    }
}
