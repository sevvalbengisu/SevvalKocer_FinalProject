using SevvalKocer_FinalP.Data;
using SevvalKocer_FinalP.Models;
using SQLite;

namespace SevvalKocer_FinalP.Services;

public class RestaurantService
{
    private readonly AppDbContext _ctx;

    public RestaurantService(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public Task<List<Restaurant>> GetRestaurantsByCategoryAsync(int categoryId)
        => _ctx.Db.Table<Restaurant>().Where(r => r.CategoryId == categoryId).ToListAsync();

    public async Task<List<string>> GetDistinctRegionsAsync()
    {
        var rows = await _ctx.Db.Table<Restaurant>().ToListAsync();

        return rows
            .Select(r => r.Region)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Distinct()
            .OrderBy(s => s)
            .ToList()!;
    }
    
    public async Task<List<Restaurant>> FilterAndSortAsync(int categoryId, string? region, bool priceAsc)
    {
        var list = await GetRestaurantsByCategoryAsync(categoryId);

        if (!string.IsNullOrWhiteSpace(region) && region != "Tüm")
            list = list.Where(r => r.Region == region).ToList();

        list = priceAsc
            ? list.OrderBy(r => r.AvgPrice).ToList()
            : list.OrderByDescending(r => r.AvgPrice).ToList();

        return list;
    }

    public Task<Restaurant?> GetRestaurantByIdAsync(int id)
        => _ctx.Db.Table<Restaurant>().Where(r => r.Id == id).FirstOrDefaultAsync();
}