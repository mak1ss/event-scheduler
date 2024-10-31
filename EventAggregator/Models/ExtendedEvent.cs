using EventAggregator.Models.Events;
using EventAggregator.Models.Feedbacks;

namespace EventAggregator.Models
{
    public class ExtendedEvent
    {
        public Event Event { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
    }
}
