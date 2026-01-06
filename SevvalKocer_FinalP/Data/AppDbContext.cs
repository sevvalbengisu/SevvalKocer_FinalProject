using SQLite;
using SevvalKocer_FinalP.Models;

namespace SevvalKocer_FinalP.Data;

public class AppDbContext
{
    public SQLiteAsyncConnection Db { get; }

    public AppDbContext(string dbPath)
    {
        Db = new SQLiteAsyncConnection(dbPath);
    }

    public async Task InitAsync()
    {
        await Db.CreateTableAsync<User>();
        await Db.CreateTableAsync<FoodCategory>();
        await Db.CreateTableAsync<Restaurant>();
        await Db.CreateTableAsync<OrderRecord>();
        await Db.CreateTableAsync<FavoriteRecord>();
    }
}