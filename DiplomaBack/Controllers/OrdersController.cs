using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiplomaBack.DAL.Entities.Order;
using DiplomaBack.DAL.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using System;
using DiplomaBack.Models;

namespace DiplomaBack.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    [EnableCors("MyPolicy")]
    public class OrdersController : Controller
    {
        private readonly DataBaseContext _context;

        public OrdersController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<OrderModel> GetOrders()
        {
            return _context.Orders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderModel = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);

            if (orderModel == null)
            {
                return NotFound();
            }

            return Ok(orderModel);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderModel([FromRoute] int id, [FromBody] OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        private double GetTotalSumm(OrderViewModel orderModel)
        {
            var totalSumm = 0.0;
            foreach (var dish in orderModel.Dishes)
            {
                var dishItem = _context.Dishes.First(x=> x.Id == dish.Id);
                totalSumm += dishItem.Price * dish.Quantity;
            }
            return totalSumm;
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrderModel([FromBody] OrderViewModel orderModel)
        {
            if (!ModelState.IsValid || GetTotalSumm(orderModel) != orderModel.OrderPrice)
            {
                return BadRequest(ModelState);
            }
            var orderModelTemp = new OrderModel
            {
                DateTime = orderModel.DateTime,
                DeliveryAddress = orderModel.DeliveryAddress,
                OrderPrice = orderModel.OrderPrice,
                Id = orderModel.Id,
                PhoneNumber = orderModel.PhoneNumber
            };
            _context.Orders.Add(orderModelTemp);
            await _context.SaveChangesAsync();
            var orderId = _context.Orders.Last().Id;
            foreach (var dish in orderModel.Dishes)
            {
                var dishOrderModel = new DishOrderModel
                {
                    Quantity = dish.Quantity,
                    OrderId = orderId,
                    DishId = dish.Id
                };
                _context.DishOrders.Add(dishOrderModel);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetOrderModel", new { id = orderModel.Id }, orderModel);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderModel = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderModel);
            await _context.SaveChangesAsync();

            return Ok(orderModel);
        }

        private bool OrderModelExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}