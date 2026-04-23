using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimerAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiPrimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return await _service.GetAllProducts();
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetProductById(id);

            if (product == null)
                return NotFound();

            return product;
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _service.AddProduct(product);
            return Ok("Producto creado correctamente");
        }

        // PUT: api/product
        [HttpPut]
        public async Task<ActionResult> Update(Product product)
        {
            await _service.UpdateProduct(product);
            return Ok("Producto actualizado");
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteProduct(id);
            return Ok("Producto eliminado");
        }
    }
}
