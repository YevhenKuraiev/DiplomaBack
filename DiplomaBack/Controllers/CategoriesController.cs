﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiplomaBack.DAL.Entities;
using DiplomaBack.DAL.EntityFrameworkCore;

namespace DiplomaBack.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly DataBaseContext _context;

        public CategoriesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<CategoryModel> GetCategories()
        {
            return _context.Categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryModel = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return Ok(categoryModel);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryModel([FromRoute] int id, [FromBody] CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelExists(id))
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

        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> PostCategoryModel([FromBody] CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categories.Add(categoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryModel", new { id = categoryModel.Id }, categoryModel);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryModel = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();

            return Ok(categoryModel);
        }

        private bool CategoryModelExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}