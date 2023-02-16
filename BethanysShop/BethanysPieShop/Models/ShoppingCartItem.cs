using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public int Amount { get; set; }

        [StringLength(200)]
        public String ShoppingCartId { get; set; }

        public Pie Pie { get; set; }

    }
}
