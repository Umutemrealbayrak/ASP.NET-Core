using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.DTO;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductsController(ProductContext context)
        {
            _context=context;   
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products=await _context.Products.Where(i=>i.IsActive).Select(p=> productToDTO(p)).ToListAsync();
            return Ok(products);
        }

        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Where(i => i.IsActive && i.ProductId == id)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

    var productDTO = productToDTO(product); // DTO dönüşümünü burada yapıyoruz.

    return Ok(productDTO);
}
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct),new { id = entity.ProductId },entity);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePoduct(int id,Product entity)
        {
            if(id!=entity.ProductId)
            {
                return BadRequest();
            }
            var product=await _context.Products.FirstOrDefaultAsync(i=>i.ProductId == id);
            if(product==null)
            {
                return NotFound();
            }
            product.ProductName=entity.ProductName;
            product.price=entity.price;
            product.IsActive=entity.IsActive;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return NotFound();
            }

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var product= await _context.Products.FirstOrDefaultAsync(i=>id==i.ProductId);
            if(product==null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();

           
        }
        private static ProductDTO productToDTO(Product p)
           {
                var entity = new ProductDTO();
            if(p != null) 
            {
                entity.ProductId = p.ProductId;
                entity.ProductName = p.ProductName;
                entity.price = p.price;
            }
            return entity;
           }
    }
}