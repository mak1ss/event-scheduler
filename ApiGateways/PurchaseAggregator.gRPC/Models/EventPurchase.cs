using Models.Events;
using Models.Tickets;

namespace PurchaseAggregator.gRPC.Models
{
    public class EventPurchase
    {
        public Event Event { get; set; }
        public IEnumerable<Ticket> purchasedTickets { get; set; }
    }
}
