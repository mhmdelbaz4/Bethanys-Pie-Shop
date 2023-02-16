using BethanysPieShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class ShoppingCartSummary :ViewComponent
    {
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }


        public IViewComponentResult Invoke()
        {
            ViewBag.total = shoppingCart.GetShoppingCartItems().Count();

            return View();
        }

    }
}
