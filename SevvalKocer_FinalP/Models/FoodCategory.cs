using SQLite;

namespace SevvalKocer_FinalP.Models;

public class FoodCategory
{
    [PrimaryKey] public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? ColorHex { get; set; }
}