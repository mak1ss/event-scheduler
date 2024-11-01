﻿namespace EventAggregator.Models.Feedbacks
{
    public class Feedback
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int EventId { get; set; }

        public List<Like> Likes { get; set; }
    }
}