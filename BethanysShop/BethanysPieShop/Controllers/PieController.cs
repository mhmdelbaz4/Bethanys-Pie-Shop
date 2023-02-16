using BethanysPieShop.Data;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepository;

        public PieController(IPieRepository pieRepository)
        {
            this.pieRepository = pieRepository;
        }

        public IActionResult Index(string category)
        {
            var pieIndexViewModel = new PieIndexViewModel();

            if (category == null)
            {
                pieIndexViewModel.Pies = pieRepository.GetAllPies();
                pieIndexViewModel.CurrentCategory = "All Categories";
                return View(pieIndexViewModel);
            }

            pieIndexViewModel.Pies = pieRepository.PiesByCategory(category);

            pieIndexViewModel.CurrentCategory = category;

            return View(pieIndexViewModel);
        }

        public IActionResult Details(int pieId)
        {
            var pie = pieRepository.PieById(pieId);

            if (pie == null)
                return NotFound();

            return View(pie);
        }

    }
}
