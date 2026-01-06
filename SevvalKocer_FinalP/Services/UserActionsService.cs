using SevvalKocer_FinalP.Data;
using SevvalKocer_FinalP.Models;

namespace SevvalKocer_FinalP.Services;

public class UserActionsService
{
    private readonly AppDbContext _ctx;

    public UserActionsService(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public Task<List<OrderRecord>> GetOrdersAsync()
        => _ctx.Db.Table<OrderRecord>()
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

    public Task<List<FavoriteRecord>> GetFavoritesAsync()
        => _ctx.Db.Table<FavoriteRecord>()
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

    public async Task AddOrderAsync(int categoryId, string productName, string restaurantName, decimal price)
    {
        await _ctx.Db.InsertAsync(new OrderRecord
        {
            CategoryId = categoryId,
            ProductName = productName,
            RestaurantName = restaurantName,
            Price = price,
            CreatedAt = DateTime.UtcNow
        });
    }

    public async Task AddFavoriteAsync(int categoryId, string productName, string restaurantName, decimal price)
    {
        await _ctx.Db.InsertAsync(new FavoriteRecord
        {
            CategoryId = categoryId,
            ProductName = productName,
            RestaurantName = restaurantName,
            Price = price,
            CreatedAt = DateTime.UtcNow
        });
    }

    public async Task RemoveOrderByFieldsAsync(string productName, string restaurantName, decimal price, DateTime createdAt)
    {
        var item = await _ctx.Db.Table<OrderRecord>()
            .Where(x => x.ProductName == productName
                        && x.RestaurantName == restaurantName
                        && x.Price == price
                        && x.CreatedAt == createdAt)
            .FirstOrDefaultAsync();

        if (item != null)
            await _ctx.Db.DeleteAsync(item);
    }

    public async Task RemoveFavoriteByFieldsAsync(string productName, string restaurantName, decimal price, DateTime createdAt)
    {
        var item = await _ctx.Db.Table<FavoriteRecord>()
            .Where(x => x.ProductName == productName
                        && x.RestaurantName == restaurantName
                        && x.Price == price
                        && x.CreatedAt == createdAt)
            .FirstOrDefaultAsync();

        if (item != null)
            await _ctx.Db.DeleteAsync(item);
    }

    
    public Task DeleteOrderAsync(int orderId)
        => _ctx.Db.DeleteAsync<OrderRecord>(orderId);

    public Task DeleteFavoriteAsync(int favoriteId)
        => _ctx.Db.DeleteAsync<FavoriteRecord>(favoriteId);
    
    public Task<int> RemoveOrderAsync(int id)
        => _ctx.Db.DeleteAsync<OrderRecord>(id);

    public Task<int> RemoveFavoriteAsync(int id)
        => _ctx.Db.DeleteAsync<FavoriteRecord>(id);
}