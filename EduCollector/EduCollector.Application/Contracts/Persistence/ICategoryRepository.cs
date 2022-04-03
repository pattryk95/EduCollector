using EduCollector.Domain;

namespace EduCollector.Application
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithPast(SearchCategoryOptions searchCategory);
    }
}
