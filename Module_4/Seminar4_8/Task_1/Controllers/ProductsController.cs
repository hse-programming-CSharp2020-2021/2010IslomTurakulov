using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace Task_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Products> productsList = new List<Products>()
        {
            new Products() {Id = 1, Name = "Artem", Price = 200000000},
            new Products() {Id = 2, Name = "Rafaat", Price = 200000000},
            new Products() {Id = 3, Name = "Igor", Price = 200000000}
        };

        [HttpGet]
        public IEnumerable<Products> Get() => productsList;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productsList.SingleOrDefault(k => k.Id.Equals(id));
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        private int NextProductId => productsList.Count == 0 ? 1 : productsList.Max(x => x.Id) + 1;

        [HttpGet("GetNextProductId")]
        public int GetNextProductId() => NextProductId;
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           productsList.Remove(productsList.SingleOrDefault(k => k.Id.Equals(id)));
           return Ok();
        }

        [HttpPost]
        public IActionResult Post(Products product)
        {
            product.Id = NextProductId;
            productsList.Add(product);
            return CreatedAtAction(nameof(Get), new {id = product.Id}, product);
        }

        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] Products product) => Post(product);


        [HttpPut]
        public IActionResult Put(Products product)
        {
            var storedProduct = productsList.SingleOrDefault(p => p.Id == product.Id);
            if (storedProduct == null)
                return NotFound();
            storedProduct.Name = product.Name;
            storedProduct.Price = product.Price;
            return Ok(storedProduct);
        }
    }
}
