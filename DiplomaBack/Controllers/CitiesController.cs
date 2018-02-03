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
    [Route("api/Cities")]
    public class CitiesController : Controller
    {
        private readonly DataBaseContext _context;

        public CitiesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public IEnumerable<CityModel> GetCities()
        {
            return _context.Cities;
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cityModel = await _context.Cities.SingleOrDefaultAsync(m => m.Id == id);

            if (cityModel == null)
            {
                return NotFound();
            }

            return Ok(cityModel);
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityModel([FromRoute] int id, [FromBody] CityModel cityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cityModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cityModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityModelExists(id))
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

        // POST: api/Cities
        [HttpPost]
        public async Task<IActionResult> PostCityModel([FromBody] CityModel cityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cities.Add(cityModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityModel", new { id = cityModel.Id }, cityModel);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cityModel = await _context.Cities.SingleOrDefaultAsync(m => m.Id == id);
            if (cityModel == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(cityModel);
            await _context.SaveChangesAsync();

            return Ok(cityModel);
        }

        private bool CityModelExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}