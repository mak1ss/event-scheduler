using AutoMapper;
using Events.DAL.Entities;
using Events.DAL.Interfaces;
using Events.DAL.Interfaces.Repositories;
using Events.BLL.DTO.Category;
using Events.BLL.Interfaces.Services;

namespace Events.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryRepository repo;

        public CategoryService(IUnitOfWork unit, IMapper mapper) {
            this.mapper = mapper;
            unitOfWork = unit;
            repo = unitOfWork.CategoryRepository;
        }

        public async Task DeleteAsync(int id)
        {
            await repo.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryResponse>> GetAsync()
        {
            var entities = await repo.GetAsync();
            return entities.Select(mapper.Map<Category, CategoryResponse>);
        }

        public async Task<CategoryResponse> GetByIdAsync(int id)
        {
            var entity = await repo.GetByIdAsync(id);
            return mapper.Map<Category, CategoryResponse>(entity);
        }

        public async Task InsertAsync(CategoryRequest request)
        {
            await repo.InsertAsync(mapper.Map<CategoryRequest, Category>(request));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryRequest request)
        {
            await repo.UpdateAsync(mapper.Map<CategoryRequest, Category>(request));
            await unitOfWork.SaveChangesAsync();
        }
    }
}
