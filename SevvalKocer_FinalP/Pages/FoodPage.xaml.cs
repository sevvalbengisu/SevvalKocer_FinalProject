using SevvalKocer_FinalP.Services;

namespace SevvalKocer_FinalP.Pages;

[QueryProperty(nameof(Country), "country")]
public partial class FoodPage : ContentPage
{
    private readonly FoodService _foodService;

    public string Country { get; set; } = "All";

    public FoodPage(FoodService foodService)
    {
        InitializeComponent();
        _foodService = foodService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var c = string.IsNullOrWhiteSpace(Country) ? "All" : Country;
        CountryTitle.Text = $"Top foods in {c}";

        var list = _foodService.GetTopDishesByCountry(c);
        FoodList.ItemsSource = list;
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}