using AutoMapper;
using Domain.Entities;

namespace Application.Tickets.Dto
{
    public class GetTicketResponse
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PurchaseId { get; set; }


        private class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<Ticket, GetTicketResponse>();
            }
        }
    }
}
