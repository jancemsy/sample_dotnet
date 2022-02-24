using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using reach_soundbite_api.Models;
using System.Web.Http;
using System.Net; 

using System.Net.Http;

namespace reach_soundbite_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static readonly IProductRepository repository = new ProductRepository();

        [HttpGet]
        [Route("all")]
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }

           

            return Ok(item);
        }

        [HttpGet]
        [Route("category/{category}")]
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        [HttpPost] 
        public IActionResult PostProduct(Product item)
        {
            item = repository.Add(item);

            return Ok(item); 
        }

        [HttpPut]
        public IActionResult PutProduct(int id, Product product)
        {
            product.Id = id;
            var result = repository.Update(product);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }


}