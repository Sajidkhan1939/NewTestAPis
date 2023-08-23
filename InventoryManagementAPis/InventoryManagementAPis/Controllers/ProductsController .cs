using InventoryManagementAPis.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products= await _context.Products.ToListAsync();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (ProductExists(product.Id))
            { 
                return Ok("product already exists");
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            if (id != existingProduct.Id)
            {
                return BadRequest();
            }

            // Update the properties of the existing product
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;

            try
            {
                
                _context.Entry(existingProduct).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
                
            }

            return Ok("Successfully updated");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        [Route("RecordSale")]
        [HttpPost]
        public async Task<ActionResult<Sale>> RecordSale(Sale sale)
        {
            var product = await _context.Products.FindAsync(sale.ProductId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            if (product.Quantity < sale.Quantity)
            {
                return BadRequest("Insufficient product quantity");
            }

            product.Quantity -= sale.Quantity;
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return Ok(sale);
        }
        [Route("TrackPurchase")]
        [HttpPost]
        public async Task<ActionResult<Purchase>> TrackPurchase(Purchase purchase)
        {
            var product = await _context.Products.FindAsync(purchase.ProductId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            product.Quantity += purchase.Quantity;
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return Ok(purchase);
        }


    }
}
