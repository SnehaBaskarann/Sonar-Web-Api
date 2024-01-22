using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Data;

namespace Web_Api.Model{

    [ApiController]
   [Route(" api/[controller]")]

   public class ProductController : ControllerBase
   {
      private readonly ApiDbContext _context;
      public ProductController(ApiDbContext context)
      {
         _context = context;
      }

      [HttpGet]
      public async Task<ActionResult<List<Product>>> GetProducts()
      {
         return Ok(await _context.Products.ToListAsync());
      }



      [HttpGet("{id}")]
      public ActionResult<Product> GetProducts(int id)
      {
         var Prod = _context.Products.Find(id);
         if (Prod == null)
         {
            return NotFound();
         }
         return Prod;
      }


      [HttpPost]

      public async Task<ActionResult<Product>> Create(Product Products)
      {
         _context.Add(Products);

         await _context.SaveChangesAsync();
         return Ok(Products);
      }


      [HttpPut("{id}")]
      public async Task<ActionResult> Update(int id, Product Prod)
      {
        
         if (id != Prod.Id)
            return BadRequest();
         _context.Entry(Prod).State = EntityState.Modified;
         await _context.SaveChangesAsync();
         return Ok();
      }


      [HttpDelete("{id}")]

      public async Task<IActionResult> Delete(int id)
      {
         var Prod = await _context.Products.FindAsync(id);
         if (Prod == null)
         {
            return NotFound("Incorrect Product Id");
         }

         _context.Products.Remove(Prod);
         await _context.SaveChangesAsync();

         return Ok();
      }


   }
}