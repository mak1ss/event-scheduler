
using AutoMapper;
using Events.DAL.Entities;
using Events.BLL.DTO.Category;
using Events.BLL.DTO.Events;
using Events.BLL.DTO.Tag;
using Events.WEBAPI.Protos;

namespace Events.BLL.Configs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateCategoryMapping();
            CreateTagMapping();
            CreateEventMapping();

            CreateCategoryGrpcMapping();
            CreateTagGrpcMapping();
            CreateEventGrpcMapping();
        }

        private void CreateCategoryMapping()
        {
            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();
        }

        private void CreateEventMapping()
        {
            CreateMap<EventRequest, Event>();
            CreateMap<Event, EventResponse>();
        }

        private void CreateTagMapping()
        {
            CreateMap<TagRequest, Tag>();
            CreateMap<Tag, TagResponse>();
        }


        // Grpc responses

        private void CreateCategoryGrpcMapping()
        {
            CreateMap<CategoryResponse, CategoryGrpcResponse>();
        }

        private void CreateEventGrpcMapping()
        {
            CreateMap<EventResponse, EventGrpcResponse>();
        }

        private void CreateTagGrpcMapping()
        {
            CreateMap<TagResponse, TagGrpcResponse>();
        }
    }
}
