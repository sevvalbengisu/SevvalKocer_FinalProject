using SQLite;

namespace SevvalKocer_FinalP.Models;

public class OrderRecord
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string ProductName { get; set; } = "";
    public string RestaurantName { get; set; } = "";

    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}