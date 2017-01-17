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
        public int GetCount()
        {
            int? count = (from cartItems in _shoppingCart.All
                          where cartItems.CartId == "4"
                          select (int?)cartItems.TotalItems).Sum();
            return count ?? 0;
        }
        public ShoppingCartListDto GetCartDto()
        {
            string cartId = "4";// Convert.ToString(HttpContext.Current.Session["userId"]);
            var cartItems = new List<CartItemDto>();
            var carts = _shoppingCart.All.Where(x => x.CartId == cartId).ToList();
            int itemIdTemp = 0;
            foreach (var cart in carts)
            {
                cartItems.Add(new CartItemDto
                {
                    Title = cart.Item.Book.Title,
                    Author = cart.Item.Book.Author,
                    Price = cart.Item.Price,
                    Quantity = carts.Count(x => x.ItemId == cart.ItemId),
                    RecordId = cart.Id,
                });
                itemIdTemp = cart.ItemId;
            }
            var cartDto = new ShoppingCartListDto()
            {
                UserId = cartId,
                CartItems = cartItems,
                CartTotal = 15,
                Count = GetCount()
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
            ShoppingCartListDto cartDto = null;
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
                            UserId = 4,
                            TotalItems = 1,
                            DateCreated = DateTime.Now,
                            ItemId = bookVm.BookId
                        };
                        _shoppingCart.Add(cart);
                    }
                    else
                    {
                        cart.TotalItems++;
                    }
                }
                _unitOfWork.Commit();
            }
            cartDto = GetCartDto();
            return Ok(cartDto);
        }

        [Route("removefromcart")]
        [HttpPost]
        public IHttpActionResult RemoveFromCart(string cartItemId)
        {
            try
            {
                var cartItem = _shoppingCart.All.Single(p => p.Id == Convert.ToInt32(cartItemId));
                _shoppingCart.Delete(cartItem);
                _unitOfWork.Commit();
                var removeFromCartDto = new RemoveFromCartDto
                {
                    Message = "The item has been removed successfully",
                    DeleteId = Convert.ToInt32(cartItemId),
                    CartTotal = 15,
                    ItemCount = GetCount()
                };
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
