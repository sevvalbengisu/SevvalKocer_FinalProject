using System.Text.Json;
using SevvalKocer_FinalP.Data;
using SevvalKocer_FinalP.Models;

namespace SevvalKocer_FinalP.Services;

public class SeedService
{
    private readonly AppDbContext _ctx;

    public SeedService(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task EnsureSeededAsync()
    {
        
        await _ctx.InitAsync();
        
        var anyCategory = await _ctx.Db.Table<FoodCategory>().FirstOrDefaultAsync();
        if (anyCategory != null) return;
        
        //demo user
        await _ctx.Db.InsertAsync(new User
        {
            Id = 1,
            Name = "Şevval Bengisu Koçer",
            Phone = "533 432 4565",
            Address = "Altunizade / Dadaşlar Sok / Üsküdar / İstanbul",
            Email = "demo@mail.com",
            Lat = 41.0,
            Lng = 29.0
        });

        
        var categories = await ReadJsonAsync<List<FoodCategory>>("categories.json");
        var restaurants = await ReadJsonAsync<List<Restaurant>>("restaurants.json");
        
        var menuItems = await ReadJsonAsync<List<ProductItem>>("MenuItems.json");
        
        await _ctx.Db.InsertAllAsync(categories);
        await _ctx.Db.InsertAllAsync(restaurants);
        await _ctx.Db.InsertAllAsync(menuItems);
    }

    private static async Task<T> ReadJsonAsync<T>(string fileName)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
        return (await JsonSerializer.DeserializeAsync<T>(stream))!;
    }
}