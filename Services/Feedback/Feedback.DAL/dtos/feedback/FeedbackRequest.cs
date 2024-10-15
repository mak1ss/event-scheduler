using System.ComponentModel.DataAnnotations;     

namespace ADO_Dapper_ServiceManagment.DAL.dtos.feedback
{
    public class FeedbackRequest
    {
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Рейтинг має бути між 1 і 5.")]
        public int Rating { get; set; }

        public int EventId { get; set; }
    }
}
