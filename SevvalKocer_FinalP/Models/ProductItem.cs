using SQLite;

namespace SevvalKocer_FinalP.Models;

public class ProductItem
{
    [PrimaryKey] public int Id { get; set; }

    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public int RestaurantId { get; set; }
    
    public string? CountryCode { get; set; } 
}