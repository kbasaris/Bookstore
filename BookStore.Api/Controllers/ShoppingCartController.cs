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
    [Authorize]
    public class ShoppingCartController : ApiController
    {
        private CustomMappings _customMappings = new CustomMappings();
        public readonly IEntityBaseRepository<ShoppingCart> _shoppingCartRepository;
        public readonly IEntityBaseRepository<Order> _orders;
        public readonly IEntityBaseRepository<OrderDetail> _orderDetail;
        private readonly IEntityBaseRepository<Item> _itemRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ShoppingCartController(
            IEntityBaseRepository<ShoppingCart> shoppingCart,
            IEntityBaseRepository<Order> orders,
            IEntityBaseRepository<OrderDetail> orderDetail,
            IEntityBaseRepository<Item> itemRepository,
            IUnitOfWork unitOfWork)
        {
            _shoppingCartRepository = shoppingCart;
            _orders = orders;
            _orderDetail = orderDetail;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }
      
        [Route("getcart")]
        public IHttpActionResult GetCart(string userId)
        {

            var cartDto = GetCartDto(userId);
            return Ok(cartDto);
        }
        [Route("addtocart")]
        [HttpPost]
        public IHttpActionResult AddToCart(string bookId,string userId)
        {
            int bookIdd = Convert.ToInt32(bookId);
            ShoppingCartListDto cartDto = null;
            if (bookIdd != 0)
            {
                var itemIdExcept = _itemRepository
                         .All.Select(x => x.Id)
                         .Except(_shoppingCartRepository
                         .All.Select(x => x.ItemId))
                         .ToList();

                if (itemIdExcept.Count > 0)
                {
                    var cart = new ShoppingCart
                    {
                        UserId = userId,
                        TotalItems = 1,
                        DateCreated = DateTime.Now,
                        ItemId = itemIdExcept.First()
                    };
                    _shoppingCartRepository.Add(cart);
                }
                else
                {
                    BadRequest("The Book has not items in stock");
                }
            }
            _unitOfWork.Commit();
            cartDto = GetCartDto(userId);
            return Ok(cartDto);
        }
        [Route("removefromcart")]
        [HttpPost]
        public IHttpActionResult RemoveFromCart(string cartItemId,string userId)
        {
            try
            {
                int bookId = 0;
                if (int.TryParse(cartItemId, out bookId))
                {
                    var items = _itemRepository.All.Where(x => x.BookID == bookId).Select(x => x.Id).ToList();
                    var itemsIntersection = items.Intersect(_shoppingCartRepository.All.Select(x => x.ItemId));
               
                    foreach (var item in itemsIntersection)
                    {
                        var cartItem = _shoppingCartRepository.All
                       .Single(p => p.ItemId == item);

                        _shoppingCartRepository.Delete(cartItem);
                    }
                   
                    _unitOfWork.Commit();

                    var removeFromCartDto = new RemoveFromCartDto
                    {
                        Message = "The item has been removed successfully",
                        DeleteId = Convert.ToInt32(cartItemId),
                        CartTotal = 15,
                        ItemCount = GetCartTotalItems(userId)
                    };
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }
        public int GetCartTotalItems(string userId)
        {
            int totalItems = 0;
            foreach (var item in GroupBy(userId))
            {
                totalItems = item.Value.Count;
            }
            return totalItems;
        }
        public Dictionary<int, List<ShoppingCart>> GroupBy(string userId)
        {
            var groupedRslt = _shoppingCartRepository.All
                 .Where(x => x.UserId == userId)
                 .GroupBy(y => y.Item.BookID)
                 .ToDictionary(s => s.Key, s => s.ToList());
            return groupedRslt;
        }
        public ShoppingCartListDto GetCartDto(string userId)
        {
            string cartId = userId;// Convert.ToString(HttpContext.Current.Session["userId"]);
            var cartItems = new List<CartItemDto>();
            var carts = GroupBy(userId);
            int totalItems = 0;
            foreach (var cart in carts)
            {
                cartItems.Add(new CartItemDto
                {
                    Title = cart.Value.Select(x => x.Item.Book.Title).First(),
                    Author = cart.Value.Select(x => x.Item.Book.Author).First(),
                    Price = cart.Value.Select(x => x.Item.Price).First(),
                    Quantity = cart.Value.Count(),
                    RecordId = cart.Key,
                });
                totalItems += cart.Value.Count();
            }
            var cartDto = new ShoppingCartListDto()
            {
                UserId = cartId,
                CartItems = cartItems,
                CartTotal = 15,
                Count = totalItems
            };
            return cartDto;
        }
    }
}
