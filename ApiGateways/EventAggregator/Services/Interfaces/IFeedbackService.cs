using EventAggregator.Models.Feedbacks;

namespace EventAggregator.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetFeedbacksByEventId(int eventId);
    }
}
