using BookStore.Data.Entities;
using BookStore.Data.Repositories;
using System.Web.Http;

namespace BookStore.Api.Controllers
{
    public class ShoppingCartController : ApiController
    {
        public readonly IEntityBaseRepository<ShoppingCart> _shoppingCart;
        public readonly IEntityBaseRepository<Order> _orders;
        public readonly IEntityBaseRepository<OrderDetail> _orderDetail;

        public ShoppingCartController(IEntityBaseRepository<ShoppingCart> shoppingCart, 
            IEntityBaseRepository<Order> orders, IEntityBaseRepository<OrderDetail> orderDetail)
        {
            _shoppingCart = shoppingCart;
            _orders = orders;
            _orderDetail = orderDetail;
        }
    }
}
