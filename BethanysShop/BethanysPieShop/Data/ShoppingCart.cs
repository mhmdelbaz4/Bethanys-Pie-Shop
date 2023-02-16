using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Data
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext context;

        private ShoppingCart(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();

            string CartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", CartId);

            return new ShoppingCart(context){ShoppingCartId = CartId};
        }
        
        public void AddToCart(Pie pie)
        {
            var shoppingCartItem = context.ShoppingCartItems
                                           .SingleOrDefault(item => item.Pie.PieId == pie.PieId && item.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    Pie = pie,
                    ShoppingCartId = ShoppingCartId,
                    Amount = 1
                };
                context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount ++;
            }
            context.SaveChanges();
        }

        public void RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = context.ShoppingCartItems
                                           .SingleOrDefault(item => item.Pie.PieId == pie.PieId && item.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                    shoppingCartItem.Amount--;
                else
                    context.ShoppingCartItems.Remove(shoppingCartItem);
            }
            context.SaveChanges();
        }
        
        public void ClearCart()
        {
            var shoppingCartItems = context.ShoppingCartItems.Where(item => item.ShoppingCartId == ShoppingCartId).ToList();

            context.RemoveRange(shoppingCartItems);

            context.SaveChanges();
        }
        
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = context.ShoppingCartItems.Where(item => item.ShoppingCartId == ShoppingCartId)
                                            .Include(item => item.Pie).ToList());
        }
        public decimal GetTotal()
        {
            decimal total = (from item in context.ShoppingCartItems
                             where item.ShoppingCartId == ShoppingCartId
                             select item.Pie.Price * item.Amount).Sum();

            return total;
        }
    }
}
