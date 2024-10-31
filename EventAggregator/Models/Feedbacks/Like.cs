namespace EventAggregator.Models.Feedbacks
{
    public class Like
    {
        public int Id { get; set; }

        public int FeedbackId { get; set; }

        public int UserId { get; set; }

        public DateTime? LikedAt { get; set; }
    }
}
