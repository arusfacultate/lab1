using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1_web_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab1_web_api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private ProductsDbContext context;
        public ProductsController(ProductsDbContext context)
        {
            this.context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = context.Products.FirstOrDefault(Product => Product.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] Product Product)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            context.Products.Add(Product);
            context.SaveChanges();
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product Product)
        {
            var existing = context.Products.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                context.Products.Add(Product);
                context.SaveChanges();
                return Ok(Product);
            }
            Product.Id = id;
            context.Products.Update(Product);
            context.SaveChanges();
            return Ok(Product);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Products.FirstOrDefault(Product => Product.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Products.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }
}
