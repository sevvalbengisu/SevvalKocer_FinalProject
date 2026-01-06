using SevvalKocer_FinalP.Data;
using SevvalKocer_FinalP.Models;

namespace SevvalKocer_FinalP.Services;

public partial class FoodService
{
    private readonly AppDbContext _ctx;

    public FoodService(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<FoodCategory?> GetRandomCategoryAsync()
    {
        var list = await _ctx.Db.Table<FoodCategory>().ToListAsync();
        if (list.Count == 0) return null;

        var rnd = new Random();
        return list[rnd.Next(list.Count)];
    }

    public Task<List<FoodCategory>> GetAllCategoriesAsync()
        => _ctx.Db.Table<FoodCategory>().ToListAsync();

    public Task<FoodCategory?> GetCategoryByIdAsync(int id)
        => _ctx.Db.Table<FoodCategory>().Where(x => x.Id == id).FirstOrDefaultAsync();
}

public partial class FoodService
{
    public class CountryDishCard
    {
        public string Name { get; set; } = "";
        public string Ingredients { get; set; } = "";
        public string PopularRestaurant { get; set; } = "";
    }
    
    public List<string> GetCountries()
        => new()
        {
            "All",
            "Turkey",
            "Italy",
            "Japan",
            "Mexico",
            "Spain",
            "France",
            "USA",
            "India",
            "China",
            "Greece"
        };
    
    public List<CountryDishCard> GetTopDishesByCountry(string? country)
    {
        country ??= "All";
        
        if (country == "All")
        {
            return new List<CountryDishCard>
            {
                new() { Name="İskender", Ingredients="beef döner, yogurt, tomato sauce, butter", PopularRestaurant="Bursa Kebapçısı" },
                new() { Name="Sushi", Ingredients="rice, nori, salmon, soy sauce", PopularRestaurant="SushiCo" },
                new() { Name="Pizza Margherita", Ingredients="tomato, mozzarella, basil", PopularRestaurant="L’Antica Pizzeria" },
                new() { Name="Tacos", Ingredients="tortilla, beef, onion, salsa", PopularRestaurant="Taquería Local" },
                new() { Name="Paella", Ingredients="rice, seafood, saffron, peas", PopularRestaurant="La Pepica" },
                new() { Name="Croissant", Ingredients="butter, flour, yeast", PopularRestaurant="Maison Kayser" },
                new() { Name="Burger", Ingredients="beef patty, bun, cheese, pickles", PopularRestaurant="Shake Shack" },
                new() { Name="Butter Chicken", Ingredients="chicken, tomato sauce, butter, spices", PopularRestaurant="Spice House" },
                new() { Name="Kung Pao Chicken", Ingredients="chicken, peanuts, chili, soy sauce", PopularRestaurant="Sichuan Kitchen" },
                new() { Name="Greek Salad", Ingredients="tomato, cucumber, feta, olives", PopularRestaurant="Taverna" }
            };
        }
        
        return country switch
        {
            "Turkey" => new()
            {
                new() { Name="İskender", Ingredients="beef döner, yogurt, tomato sauce, butter", PopularRestaurant="Bursa Kebapçısı" },
                new() { Name="Lahmacun", Ingredients="thin dough, minced meat, parsley, spices", PopularRestaurant="Halil Lahmacun" },
                new() { Name="Mantı", Ingredients="dumplings, yogurt, garlic, butter sauce", PopularRestaurant="Kayseri Sofrası" },
                new() { Name="Adana Kebab", Ingredients="spicy minced meat, skewer, lavash", PopularRestaurant="Adana Ocakbaşı" },
                new() { Name="Kuru Fasulye", Ingredients="beans, tomato paste, onion, meat (optional)", PopularRestaurant="Kanaat Lokantası" },
                new() { Name="Menemen", Ingredients="eggs, tomato, pepper, onion", PopularRestaurant="Van Kahvaltı Evi" },
                new() { Name="Baklava", Ingredients="phyllo, pistachio, syrup, butter", PopularRestaurant="Güllüoğlu" },
                new() { Name="Köfte", Ingredients="ground meat, onion, spices", PopularRestaurant="Sultanahmet Köftecisi" },
                new() { Name="Pide", Ingredients="dough, cheese/meat, butter", PopularRestaurant="Karadeniz Pidecisi" },
                new() { Name="Simit", Ingredients="sesame, dough, molasses", PopularRestaurant="Simit Sarayı" }
            },

            "Italy" => new()
            {
                new() { Name="Pizza Margherita", Ingredients="tomato, mozzarella, basil", PopularRestaurant="L’Antica Pizzeria" },
                new() { Name="Carbonara", Ingredients="pasta, eggs, pecorino, guanciale", PopularRestaurant="Trattoria Roma" },
                new() { Name="Lasagna", Ingredients="pasta sheets, ragù, béchamel", PopularRestaurant="La Nonna" },
                new() { Name="Risotto", Ingredients="arborio rice, broth, parmesan", PopularRestaurant="Milano Risotto" },
                new() { Name="Tiramisu", Ingredients="mascarpone, espresso, cocoa", PopularRestaurant="Dolce Vita" },
                new() { Name="Pesto Pasta", Ingredients="basil, pine nuts, parmesan, olive oil", PopularRestaurant="Genova Kitchen" },
                new() { Name="Neapolitan Pizza", Ingredients="tomato, mozzarella, olive oil", PopularRestaurant="Da Michele" },
                new() { Name="Gnocchi", Ingredients="potato dumplings, sauce", PopularRestaurant="Trattoria Gnocchi" },
                new() { Name="Gelato", Ingredients="milk, sugar, flavors", PopularRestaurant="Gelateria" },
                new() { Name="Bolognese", Ingredients="ragù, tomato, minced beef, pasta", PopularRestaurant="Bologna House" }
            },

            "Japan" => new()
            {
                new() { Name="Sushi", Ingredients="rice, nori, fish, soy sauce", PopularRestaurant="SushiCo" },
                new() { Name="Ramen", Ingredients="noodles, broth, egg, pork", PopularRestaurant="Ichiraku Ramen" },
                new() { Name="Tempura", Ingredients="shrimp/veg, batter, oil", PopularRestaurant="Tokyo Tempura" },
                new() { Name="Okonomiyaki", Ingredients="cabbage, batter, sauce", PopularRestaurant="Osaka Grill" },
                new() { Name="Takoyaki", Ingredients="octopus, batter, sauce", PopularRestaurant="Street Bites" },
                new() { Name="Udon", Ingredients="thick noodles, broth, scallion", PopularRestaurant="Udon House" },
                new() { Name="Sashimi", Ingredients="fresh fish slices", PopularRestaurant="Sakana" },
                new() { Name="Katsu", Ingredients="breaded pork, cabbage", PopularRestaurant="Katsu Bar" },
                new() { Name="Onigiri", Ingredients="rice, nori, fillings", PopularRestaurant="Konbini" },
                new() { Name="Mochi", Ingredients="rice cake, sweet filling", PopularRestaurant="Mochi Lab" }
            },

            "Mexico" => new()
            {
                new() { Name="Tacos", Ingredients="tortilla, beef/chicken, salsa", PopularRestaurant="Taquería Local" },
                new() { Name="Burrito", Ingredients="tortilla, beans, rice, meat", PopularRestaurant="Burrito Bros" },
                new() { Name="Quesadilla", Ingredients="tortilla, cheese, fillings", PopularRestaurant="Quesa Corner" },
                new() { Name="Guacamole", Ingredients="avocado, lime, onion", PopularRestaurant="Casa Verde" },
                new() { Name="Nachos", Ingredients="chips, cheese, jalapeño", PopularRestaurant="Nacho Bar" },
                new() { Name="Enchiladas", Ingredients="tortilla, sauce, chicken", PopularRestaurant="El Rojo" },
                new() { Name="Churros", Ingredients="fried dough, sugar, chocolate", PopularRestaurant="Dulce Churros" },
                new() { Name="Pozole", Ingredients="hominy, pork, chili", PopularRestaurant="Pozole House" },
                new() { Name="Tamales", Ingredients="masa, filling, corn husk", PopularRestaurant="Tamale Spot" },
                new() { Name="Elote", Ingredients="corn, mayo, cheese, chili", PopularRestaurant="Street Corn" }
            },

            "Spain" => new()
            {
                new() { Name="Paella", Ingredients="rice, seafood, saffron", PopularRestaurant="La Pepica" },
                new() { Name="Tortilla Española", Ingredients="eggs, potato, onion", PopularRestaurant="Casa Tortilla" },
                new() { Name="Gazpacho", Ingredients="tomato, cucumber, olive oil", PopularRestaurant="Andaluz" },
                new() { Name="Patatas Bravas", Ingredients="potato, spicy sauce", PopularRestaurant="Tapas Bar" },
                new() { Name="Jamón", Ingredients="cured ham", PopularRestaurant="Ibérico" },
                new() { Name="Croquetas", Ingredients="béchamel, ham, crumbs", PopularRestaurant="Croqueta House" },
                new() { Name="Pulpo a la Gallega", Ingredients="octopus, paprika, olive oil", PopularRestaurant="Galicia" },
                new() { Name="Churros", Ingredients="fried dough, sugar", PopularRestaurant="Chocolatería" },
                new() { Name="Pisto", Ingredients="tomato, pepper, eggplant", PopularRestaurant="La Mancha" },
                new() { Name="Crema Catalana", Ingredients="milk, sugar, cinnamon", PopularRestaurant="Catalunya" }
            },

            _ => new()
            {
                new() { Name=$"{country} Dish 1", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant A" },
                new() { Name=$"{country} Dish 2", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant B" },
                new() { Name=$"{country} Dish 3", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant C" },
                new() { Name=$"{country} Dish 4", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant D" },
                new() { Name=$"{country} Dish 5", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant E" },
                new() { Name=$"{country} Dish 6", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant F" },
                new() { Name=$"{country} Dish 7", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant G" },
                new() { Name=$"{country} Dish 8", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant H" },
                new() { Name=$"{country} Dish 9", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant I" },
                new() { Name=$"{country} Dish 10", Ingredients="ingredients 1, 2, 3", PopularRestaurant="Restaurant J" },
            }
        };
    }
}