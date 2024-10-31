using EventAggregator.Extensions;
using EventAggregator.Models.Events;
using EventAggregator.Services.Interfaces;

namespace EventAggregator.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly HttpClient client;

        public EventService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Event> GetEventById(int id)
        {
            var response = await client.GetAsync($"api/Event/{id}");

            return await response.ReadContentAs<Event>();
        }
    }
}
