using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiplomaBack.Models;

namespace DiplomaBack.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurants")]
    public class RestaurantsController : Controller
    {
        private readonly DataBaseContext _context;

        public RestaurantsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public IEnumerable<RestaurantModel> GetRestaurants()
        {
            return _context.Restaurants;
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurantModel = await _context.Restaurants.SingleOrDefaultAsync(m => m.Id == id);

            if (restaurantModel == null)
            {
                return NotFound();
            }

            return Ok(restaurantModel);
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantModel([FromRoute] int id, [FromBody] RestaurantModel restaurantModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantModelExists(id))
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

        // POST: api/Restaurants
        [HttpPost]
        public async Task<IActionResult> PostRestaurantModel([FromBody] RestaurantModel restaurantModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restaurants.Add(restaurantModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantModel", new { id = restaurantModel.Id }, restaurantModel);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurantModel = await _context.Restaurants.SingleOrDefaultAsync(m => m.Id == id);
            if (restaurantModel == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurantModel);
            await _context.SaveChangesAsync();

            return Ok(restaurantModel);
        }

        private bool RestaurantModelExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}