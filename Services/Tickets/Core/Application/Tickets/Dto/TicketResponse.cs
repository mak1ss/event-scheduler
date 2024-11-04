using Application.Protos;
using AutoMapper;
using Domain.Entities;
using Google.Protobuf.WellKnownTypes;

namespace Application.Tickets.Dto
{
    public class TicketResponse
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
                CreateMap<Ticket, TicketResponse>();

                CreateMap<TicketResponse, PurchaseTicketResponse>()
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.CreatedAt.ToUniversalTime())));
            }
        }
    }
}
