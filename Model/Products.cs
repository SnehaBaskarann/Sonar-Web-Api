using System.ComponentModel.DataAnnotations;

namespace Web_Api.Model;

public class Product
{

    public int Id { get; set; }
    [Required]
    public string? Product_Name { get; set; }
    [Required]
    public float Price {get; set;}
    [Required]
    public int Quantity {get; set;}

   
}
