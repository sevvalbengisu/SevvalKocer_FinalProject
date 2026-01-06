namespace SevvalKocer_FinalP.Pages;
using SevvalKocer_FinalP.Services;
public partial class ExplorePage : ContentPage
{
    private readonly FoodService _foodService;

    public ExplorePage(FoodService foodService)
    {
        InitializeComponent();
        _foodService = foodService;

        CountryPicker.ItemsSource = _foodService.GetCountries();
        GoButton.IsEnabled = false;
    }

    private void OnPickerTap(object sender, EventArgs e)
        => CountryPicker.Focus();

    private void OnCountryChanged(object sender, EventArgs e)
    {
        var selected = CountryPicker.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(selected))
        {
            SelectedCountryLabel.Text = selected;
            GoButton.IsEnabled = true;
        }
        else
        {
            SelectedCountryLabel.Text = "Select a country";
            GoButton.IsEnabled = false;
        }
    }

    private async void OnGoClicked(object sender, EventArgs e)
    {
        var country = CountryPicker.SelectedItem?.ToString() ?? "All";
        await Shell.Current.GoToAsync($"{nameof(FoodPage)}?country={Uri.EscapeDataString(country)}");
    }
}