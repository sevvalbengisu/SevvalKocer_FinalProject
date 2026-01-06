using SQLite;

namespace SevvalKocer_FinalP.Models;

public class User
{
    [PrimaryKey] public int Id { get; set; } = 1;

    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Address { get; set; } = "";

    public double Lat { get; set; } = 41.0;
    public double Lng { get; set; } = 29.0;
}


