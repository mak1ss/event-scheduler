using Domain.Enums;

namespace Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public PurchaseStatus Status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? PurchasedTime { get; set; }
        public decimal? TotalAmount { get; set; }
        public IEnumerable<Ticket> PurchasedTickets { get; set; }
    }
}
