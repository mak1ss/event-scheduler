using EventAggregator.Models.Events;

namespace EventAggregator.Services.Interfaces
{
    public interface IEventService
    {
        Task<Event> GetEventById(int id);
    }
}
