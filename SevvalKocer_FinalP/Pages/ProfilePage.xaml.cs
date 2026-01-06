using SevvalKocer_FinalP.Models;
using SevvalKocer_FinalP.Services;

namespace SevvalKocer_FinalP.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly UserActionsService _userActionsService;

    public ProfilePage(UserActionsService userActionsService)
    {
        InitializeComponent();
        _userActionsService = userActionsService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        var orders = await _userActionsService.GetOrdersAsync();
        var favs = await _userActionsService.GetFavoritesAsync();

        OrdersEmptyLabel.IsVisible = orders.Count == 0;
        FavoritesEmptyLabel.IsVisible = favs.Count == 0;

        OrdersList.ItemsSource = orders.Select(o => new ActionVm(o.ProductName, o.RestaurantName, o.Price, o.CreatedAt)).ToList();
        FavoritesList.ItemsSource = favs.Select(f => new ActionVm(f.ProductName, f.RestaurantName, f.Price, f.CreatedAt)).ToList();
    }

    private async void OnRemoveOrder(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is ActionVm vm)
        {
            // RemoveOrderAsync must exist in UserActionsService
            await _userActionsService.RemoveOrderByFieldsAsync(vm.ProductName, vm.RestaurantName, vm.Price, vm.CreatedAt);
            await LoadAsync();
        }
    }

    private async void OnRemoveFavorite(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is ActionVm vm)
        {
            await _userActionsService.RemoveFavoriteByFieldsAsync(vm.ProductName, vm.RestaurantName, vm.Price, vm.CreatedAt);
            await LoadAsync();
        }
    }

    public class ActionVm
    {
        public string ProductName { get; }
        public string RestaurantName { get; }
        public decimal Price { get; }
        public DateTime CreatedAt { get; }

        public string MetaText => $"₺{Price} • {CreatedAt:dd.MM.yyyy HH:mm}";

        public ActionVm(string productName, string restaurantName, decimal price, DateTime createdAt)
        {
            ProductName = productName;
            RestaurantName = restaurantName;
            Price = price;
            CreatedAt = createdAt;
        }
    }
}
