using SQLite;

namespace SevvalKocer_FinalP.Models;

public class Restaurant
{
    [PrimaryKey] public int Id { get; set; }
    public string Name { get; set; } = "";

    public string City { get; set; } = "";
    public string District { get; set; } = "";

    
    public int PriceLevel { get; set; }

    public double Lat { get; set; }
    public double Lng { get; set; }
    public int CategoryId { get; set; }
    public string? Region { get; set; }
    public double AvgPrice { get; set; }
}