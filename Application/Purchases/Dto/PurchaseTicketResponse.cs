using AutoMapper;
using Domain.Entities;

namespace Application.Purchases.Dto
{
    public class PurchaseTicketResponse
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }      

        private class Mapper : Profile
        {
            public Mapper() 
            {
                CreateMap<Ticket, PurchaseTicketResponse>();
            }
        }
    }
}
