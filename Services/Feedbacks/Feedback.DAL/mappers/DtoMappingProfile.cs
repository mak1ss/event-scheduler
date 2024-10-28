using ADO_Dapper_ServiceManagment.DAL.dtos.feedback;
using ADO_Dapper_ServiceManagment.DAL.dtos.like;
using ADO_Dapper_ServiceManagment.DAL.entities;
using AutoMapper;

namespace ADO_Dapper_ServiceManagment.DAL.mappers
{
    public class DtoMappingProfile : Profile
    {

        public DtoMappingProfile()
        {
            CreateMap<FeedbackRequest, Feedback>();
            CreateMap<Feedback, FeedbackResponse>()
                .ForMember(dest => dest.LikesAmount, opt => opt.MapFrom(src => src.Likes.Count));
            CreateMap<Feedback, CompleteFeedbackResponse>();

            CreateMap<LikeRequest, Like>(); 
            CreateMap<Like, LikeResponse>();
        }
    }
}
