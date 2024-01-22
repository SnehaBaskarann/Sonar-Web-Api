
using Microsoft.EntityFrameworkCore;
using Web_Api.Model;
namespace Web_Api.Data
{
    public class ApiDbContext :DbContext
    {
      public ApiDbContext(DbContextOptions options)  : base(options){

      }
      public DbSet<Product>Products {get; set;}
    }

}
