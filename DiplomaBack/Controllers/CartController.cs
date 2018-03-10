using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomaBack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaBack.Controllers
{
    [Produces("application/json")]
    [EnableCors("MyPolicy")]
    public class CartController : Controller
    {
        private readonly DataBaseContext _context;
        private Cart cart;

        public CartController(DataBaseContext context, Cart cartService)
        {
            cart = cartService;
            _context = context;
        }

        //public RedirectToRouteResult AddToCart(int dishId)
        //{
        //    var dish = _context.Dishes
        //        .FirstOrDefault(g => g.Id == dishId);

        //    if (dish != null)
        //    {
        //        GetCart().AddItem(dish, 1);
        //    }
        //    return RedirectToRoute("Index");
        //}

        // POST: api/Dishes

        [HttpPost]
        public IActionResult AddToCart([FromBody]int dishId)
        {
            var dish = _context.Dishes
                .FirstOrDefault(g => g.Id == dishId);


            if (dish != null)
            {
                cart.AddItem(dish, 1);
            }
            //return CreatedAtAction("GetCart", new { id = dishId });
            return Ok();
        }

        //[HttpPost]
        //public RedirectToRouteResult RemoveFromCart(int dishId, string returnUrl)
        //{
        //    var dish = _context.Dishes
        //        .FirstOrDefault(g => g.Id == dishId);

        //    if (dish != null)
        //    {
        //        cart.RemoveLine(dish);
        //    }
        //    return RedirectToRoute("Index", new { returnUrl });
        //}

        //[HttpGet]
        //public Cart GetCart()
        //{
        //    var cart = HttpContext.Session.Get<Cart>("Cart");
        //    if (cart != null) return cart;
        //    cart = new Cart();
        //    HttpContext.Session.Set("Cart", cart);
        //    return cart;
        //}

    }
}