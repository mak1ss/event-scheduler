using EventAggregator.Extensions;
using EventAggregator.Models.Feedbacks;
using EventAggregator.Services.Interfaces;

namespace EventAggregator.Services.Implementations
{
    public class FeedbackService : IFeedbackService
    {

        private readonly HttpClient client;

        public FeedbackService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksByEventId(int eventId)
        {
            Console.WriteLine($"Base feedback addr {client.BaseAddress}");
            var response = await client.GetAsync($"api/Feedback/ByEvent/{eventId}");

            return await response.ReadContentAs<IEnumerable<Feedback>>();
        }
    }
}
