using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ShoppingCart shoppingCart;

        public OrderRepository(ApplicationDbContext context,ShoppingCart shoppingCart)
        {
            this.context = context;
            this.shoppingCart = shoppingCart;
        }

        public void AddOrder(Order order)
        {
            order.DateTimePlaced = DateTime.Now;

            var shoppingCartItems = shoppingCart.ShoppingCartItems;
            order.Total = shoppingCart.GetTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            context.Orders.Add(order);

            context.SaveChanges();
        }
    }
}
