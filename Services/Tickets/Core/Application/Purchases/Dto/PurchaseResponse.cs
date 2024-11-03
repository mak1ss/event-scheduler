using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Purchases.Dto
{
    public class PurchaseResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public PurchaseStatus Status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PurchasedTime { get; set; }
        public decimal? TotalAmount { get; set; }
        public IEnumerable<PurchaseTicketResponse> PurchasedTickets { get; set; }
        public bool IsPromoCodeUsed { get; set; } = false;

        private class Mapper : Profile
        {
            public Mapper() 
            {
                CreateMap<Purchase,  PurchaseResponse>();
            }
        }
    }
}
