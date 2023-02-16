using BethanysPieShop.Data;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPieRepository pieRepository;

        public HomeController(ILogger<HomeController> logger ,IPieRepository pieRepository)
        {
            _logger = logger;
            this.pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var piesOfTheWeek = pieRepository.GetPiesOfTheWeek();

            return View(piesOfTheWeek);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}