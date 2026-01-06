using SevvalKocer_FinalP.Pages;

namespace SevvalKocer_FinalP;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(RestaurantsPage), typeof(RestaurantsPage));
        Routing.RegisterRoute(nameof(FoodPage), typeof(FoodPage));
        Routing.RegisterRoute(nameof(FoodPage), typeof(SevvalKocer_FinalP.Pages.FoodPage));


    }
}