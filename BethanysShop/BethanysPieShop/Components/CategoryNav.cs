using BethanysPieShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class CategoryNav :ViewComponent 
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryNav(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryRepository.GetAllCategories().OrderBy(c => c.CategoryName);

            return View(categories);
        }

    }
}
