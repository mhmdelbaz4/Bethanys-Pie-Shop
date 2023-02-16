using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public decimal Total { get; set; }

    }
}
