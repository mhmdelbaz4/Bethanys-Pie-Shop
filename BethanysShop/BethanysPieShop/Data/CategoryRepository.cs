using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
    }
}
