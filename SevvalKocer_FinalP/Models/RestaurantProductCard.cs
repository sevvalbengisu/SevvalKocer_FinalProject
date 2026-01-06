namespace SevvalKocer_FinalP.Models;

public class RestaurantProductCard
{
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = "";
    public string RestaurantName { get; set; } = "";
    public decimal Price { get; set; }
}