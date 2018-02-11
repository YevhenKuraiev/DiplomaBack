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
    [Route("api/Dishes")]
    public class DishesController : Controller
    {
        private readonly DataBaseContext _context;

        public DishesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Dishes
        [HttpGet]
        public IEnumerable<DishModel> GetDishes()
        {
            return _context.Dishes;
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDishModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dishModel = await _context.Dishes.SingleOrDefaultAsync(m => m.Id == id);

            if (dishModel == null)
            {
                return NotFound();
            }

            return Ok(dishModel);
        }

        // PUT: api/Dishes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishModel([FromRoute] int id, [FromBody] DishModel dishModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dishModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishModelExists(id))
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

        // POST: api/Dishes
        [HttpPost]
        public async Task<IActionResult> PostDishModel([FromBody] DishModel dishModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dishes.Add(dishModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishModel", new { id = dishModel.Id }, dishModel);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dishModel = await _context.Dishes.SingleOrDefaultAsync(m => m.Id == id);
            if (dishModel == null)
            {
                return NotFound();
            }

            _context.Dishes.Remove(dishModel);
            await _context.SaveChangesAsync();

            return Ok(dishModel);
        }

        private bool DishModelExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }
    }
}