using BethanysPieShop.Data;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ShoppingCart shoppingCart;
        private readonly IOrderRepository orderRepository;

        public OrderController(ShoppingCart shoppingCart,IOrderRepository orderRepository)
        {
            this.shoppingCart = shoppingCart;
            this.orderRepository = orderRepository;
        }

        public IActionResult CheckOut()
        {

            return View();
        }

        [HttpPost]

        public IActionResult CheckOut(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            if(shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "your cart is empty ,add some pies first");
            }

            if(ModelState.IsValid)
            {
                orderRepository.AddOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }

            return View(order);
        }

        public IActionResult CheckOutComplete()
        {
            return View();
        }
    }
}
