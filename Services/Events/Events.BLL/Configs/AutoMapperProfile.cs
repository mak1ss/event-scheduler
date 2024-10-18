
using AutoMapper;
using Events.DAL.Entities;
using Events.BLL.DTO.Category;
using Events.BLL.DTO.Events;
using Events.BLL.DTO.Tag;

namespace Events.BLL.Configs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateCategoryMapping();
            CreateTagMapping();
            CreateEventMapping();
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
    }
}
