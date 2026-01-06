using Microsoft.Extensions.Logging;
using SevvalKocer_FinalP.Data;
using SevvalKocer_FinalP.Services;
using SevvalKocer_FinalP.Pages;

namespace SevvalKocer_FinalP;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<AppDbContext>(_ =>
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "sef.db3");
            return new AppDbContext(dbPath);
        });

        builder.Services.AddSingleton<SeedService>();
        builder.Services.AddSingleton<FoodService>();
        builder.Services.AddSingleton<RestaurantService>();
        builder.Services.AddSingleton<UserActionsService>();

        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<ExplorePage>();
        builder.Services.AddTransient<RestaurantsPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<FoodPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}