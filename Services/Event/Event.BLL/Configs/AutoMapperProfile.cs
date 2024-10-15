
using AutoMapper;
using EF_ServcieManagement.DAL.Entities;
using EF_ServiceManagement.BLL.DTO.Category;
using EF_ServiceManagement.BLL.DTO.Service;
using EF_ServiceManagement.BLL.DTO.Tag;

namespace EF_ServiceManagement.BLL.Configs
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
