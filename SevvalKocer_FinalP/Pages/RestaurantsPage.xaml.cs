using SevvalKocer_FinalP.Services;

namespace SevvalKocer_FinalP.Pages;

[QueryProperty(nameof(CategoryName), "categoryName")]
public partial class RestaurantsPage : ContentPage
{
    private readonly UserActionsService _userActionsService;

    public string CategoryName { get; set; } = "";

    private List<ProductCardVm> _baseList = new();

    public RestaurantsPage(UserActionsService userActionsService)
    {
        InitializeComponent();
        _userActionsService = userActionsService;

        
        SortPicker.ItemsSource = new List<string>
        {
            "All",
            "Price: Low to High",
            "Price: High to Low"
        };
        SortPicker.SelectedIndex = 0;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        
        if (string.IsNullOrWhiteSpace(CategoryName))
            CategoryName = "Unknown";

        CategoryLabel.Text = $"Category: {CategoryName}";

        _baseList = BuildDefault8Products();
        ProductsCollection.ItemsSource = _baseList;
    }


    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnSortIconTapped(object sender, EventArgs e)
    {
        SortPicker.Focus(); 
    }


    private void OnSortChanged(object sender, EventArgs e)
    {
        if (_baseList == null || _baseList.Count == 0) return;

        var selected = SortPicker.SelectedItem?.ToString() ?? "All";

        List<ProductCardVm> list;

        if (selected == "Price: Low to High")
            list = _baseList.OrderBy(x => x.Price).ToList();
        else if (selected == "Price: High to Low")
            list = _baseList.OrderByDescending(x => x.Price).ToList();
        else
            list = _baseList.ToList(); 

        ProductsCollection.ItemsSource = list;
    }

    private async void OnOrderClicked(object sender, EventArgs e)
    {
        if (sender is not Button btn || btn.CommandParameter is not ProductCardVm vm)
            return;

        try
        {
            await _userActionsService.AddOrderAsync(
                categoryId: 0,
                productName: vm.ProductName,
                restaurantName: vm.RestaurantName,
                price: vm.Price
            );

            
            await Shell.Current.GoToAsync("//profile");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Order Error", ex.Message, "OK");
        }
    }


    private async void OnFavoriteClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is ProductCardVm vm)
        {
            await _userActionsService.AddFavoriteAsync(
                categoryId: 0,
                productName: vm.ProductName,
                restaurantName: vm.RestaurantName,
                price: vm.Price
            );

            await DisplayAlert("Saved", "Added to favorites.", "OK");
        }
    }

    private List<ProductCardVm> BuildDefault8Products()
    {
        return new List<ProductCardVm>
        {
            new("Product A", "Restaurant 1", 220),
            new("Product B", "Restaurant 2", 180),
            new("Product C", "Restaurant 3", 260),
            new("Product D", "Restaurant 4", 200),
            new("Product E", "Restaurant 5", 150),
            new("Product F", "Restaurant 6", 310),
            new("Product G", "Restaurant 7", 170),
            new("Product H", "Restaurant 8", 280),
        };
    }

    public class ProductCardVm
    {
        public string ProductName { get; }
        public string RestaurantName { get; }
        public decimal Price { get; }
        public string PriceText => $"₺{Price}";

        public ProductCardVm(string productName, string restaurantName, decimal price)
        {
            ProductName = productName;
            RestaurantName = restaurantName;
            Price = price;
        }
    }
}
