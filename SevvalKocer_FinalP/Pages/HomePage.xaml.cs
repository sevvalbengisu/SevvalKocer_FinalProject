using SevvalKocer_FinalP.Data;
using SevvalKocer_FinalP.Services;
using SevvalKocer_FinalP.Models;

namespace SevvalKocer_FinalP.Pages;

public partial class HomePage : ContentPage
{
    private readonly SeedService _seed;
    private readonly FoodService _foodService;

    private bool _seeded = false;
    private bool _isSpinning = false;

    public HomePage(SeedService seed, FoodService foodService)
    {
        InitializeComponent();
        _seed = seed;
        _foodService = foodService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = InitAsync();
    }

    private async Task InitAsync()
    {
        try
        {
            await _seed.EnsureSeededAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", ex.Message, "OK");
        }
    }

    private async void OnSpinClicked(object sender, EventArgs e)
    {
        if (_isSpinning) return;
        _isSpinning = true;

        try
        {
            SpinButton.IsEnabled = false;
            
            WheelImage.Rotation = 0;
            await WheelImage.RotateTo(360 * 4, 900, Easing.CubicOut);

            
            var cat = await _foodService.GetRandomCategoryAsync();
            if (cat == null)
            {
                await DisplayAlert("Hata", "Kategori bulunamadı. Seed çalıştı mı?", "Tamam");
                return;
            }

            var accept = await DisplayAlert(
                cat.Name.ToUpper(),   
                "Do you want to continue?",
                "Accept",
                "Spin again"
            );

            if (accept)
            {
                
                await Shell.Current.GoToAsync($"{nameof(RestaurantsPage)}?categoryName={Uri.EscapeDataString(cat.Name)}");
            }

            else
            {
               
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Spin Hatası", ex.Message, "Tamam");
        }
        finally
        {
            SpinButton.IsEnabled = true;
            _isSpinning = false;
        }
    }
}
