using SevvalKocer_FinalP.Data;
using SevvalKocer_FinalP.Models;

namespace SevvalKocer_FinalP;

public partial class MainPage : ContentPage
{
    private readonly AppDbContext _db;

    public MainPage(AppDbContext db)
    {
        InitializeComponent();
        _db = db;

        Loaded += async (_, _) =>
        {
            var catCount = await _db.Db.Table<FoodCategory>().CountAsync();
            var resCount = await _db.Db.Table<Restaurant>().CountAsync();
            var prodCount = await _db.Db.Table<ProductItem>().CountAsync();

            ResultLabel.Text = $"Categories: {catCount} | Restaurants: {resCount} | Products: {prodCount}";
        };
    }
}