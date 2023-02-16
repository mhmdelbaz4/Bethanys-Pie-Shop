using BethanysPieShop.Data;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart shoppingCart;
        private readonly IPieRepository pieRepository;

        public ShoppingCartController(ShoppingCart shoppingCart,IPieRepository pieRepository)
        {
            this.shoppingCart = shoppingCart;
            this.pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var viewModel = new ShoppingCartViewModel()
            {
                ShoppingCartItems = shoppingCart.ShoppingCartItems,
                Total = shoppingCart.GetTotal()
            };

            return View(viewModel);
        }

        public IActionResult AddToCart(int pieId)
        {
            var pie = pieRepository.PieById(pieId);
            if (pie == null)
                return NotFound();
            shoppingCart.AddToCart(pie);

            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int pieId)
        {
            var pie = pieRepository.PieById(pieId);
            if (pie == null)
                return NotFound();
            shoppingCart.RemoveFromCart(pie);

            return RedirectToAction("Index");
        }
    }
}
