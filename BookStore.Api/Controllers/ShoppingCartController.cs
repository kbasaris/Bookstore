using BookStore.Api.Mappings;
using BookStore.Data.Entities;
using BookStore.Data.Extensions;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using BookStore.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookStore.Api.Controllers
{
    [RoutePrefix("api/cart")]
    public class ShoppingCartController : ApiController
    {
        private CustomMappings _customMappings = new CustomMappings();
        public readonly IEntityBaseRepository<ShoppingCart> _shoppingCart;
        public readonly IEntityBaseRepository<Order> _orders;
        public readonly IEntityBaseRepository<OrderDetail> _orderDetail;
        private readonly IEntityBaseRepository<Item> _itemRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(IEntityBaseRepository<ShoppingCart> shoppingCart,
            IEntityBaseRepository<Order> orders, IEntityBaseRepository<OrderDetail> orderDetail, IEntityBaseRepository<Item> itemRepository, IUnitOfWork unitOfWork)
        {
            _shoppingCart = shoppingCart;
            _orders = orders;
            _orderDetail = orderDetail;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public ShoppingCartDto GetCartDto()
        {
            string cartId = "4";// Convert.ToString(HttpContext.Current.Session["userId"]);
            var cartItems = new List<CartItemDto>();
            var carts = _shoppingCart.All.Where(x => x.CartId == cartId).ToList();
            int itemIdTemp = 0;
            foreach (var cart in carts)
            {
                if (itemIdTemp != cart.ItemId)
                {
                    cartItems.Add(new CartItemDto
                    {
                        Title = cart.Item.Book.Title,
                        Author = cart.Item.Book.Author,
                        Price = cart.Item.Price,
                        Quantity = carts.Count(x => x.ItemId == cart.ItemId)
                    });
                    itemIdTemp = cart.ItemId;
                }
            }
            var cartDto = new ShoppingCartDto()
            {
                UserId = cartId,
                CartItems = cartItems,
                CartTotal = 15
            };
            return cartDto;
        }

        [Route("getcart")]
        public IHttpActionResult GetCart()
        {

            var cartDto = GetCartDto();
            return Ok(cartDto);
        }

        [Route("addtocart")]
        [HttpPost]
        public IHttpActionResult AddToCart(string itemId)
        {
            int itemIdd = Convert.ToInt32(itemId);
            ShoppingCartDto cartDto = null;
            if (itemIdd != 0)
            {
                var item = _itemRepository.All.SingleOrDefault(x => x.Id == itemIdd);
                if (item != null)
                {
                   var bookVm = _customMappings.MapTobookVm(item);
                    var cart = _shoppingCart.All.SingleOrDefault(x => x.Item.BookID == bookVm.BookId);

                    if (cart == null)
                    {
                        cart = new ShoppingCart
                        {
                            UserId = bookVm.UserId,
                            TotalItems = 1,
                            DateCreated = DateTime.Now,
                            ItemId = bookVm.BookId
                        };
                        _shoppingCart.Add(cart);
                        _unitOfWork.Commit();
                       
                    }
                    else
                    {
                        cart.TotalItems++;
                    }
                }
            }
            cartDto = GetCartDto();
            return Ok(cartDto);

        }

    }
}
