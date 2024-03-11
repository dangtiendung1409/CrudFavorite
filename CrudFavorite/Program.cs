using Microsoft.EntityFrameworkCore;
using CrudFavorite;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FavoriteDb>(opt => opt.UseInMemoryDatabase("Favorite"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/Favorites", async (FavoriteDb db) =>
    await db.Favorites.ToListAsync());



app.MapGet("/Favorites/{id}", async (int id, FavoriteDb db) =>
    await db.Favorites.FindAsync(id)


        is Favorite Favorite
        ? Results.Ok(Favorite) : Results.NotFound());

app.MapPost("/Favorites", async (Favorite Favorite, FavoriteDb db) =>
{
    db.Favorites.Add(Favorite);
    await db.SaveChangesAsync();

    return Results.Created($"/Favorite/{Favorite.Id}", Favorite);
});

app.MapPut("/Favorites/{id}", async (int id, Favorite inputFavorite, FavoriteDb db) =>
{
    var Favorite = await db.Favorites.FindAsync(id)

;
    if (Favorite == null) return Results.NotFound();

    Favorite.ProductName = inputFavorite.ProductName;
    Favorite.Price = inputFavorite.Price;


    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Favorites/{id}", async (int id, FavoriteDb db) =>
{
    if (await db.Favorites.FindAsync(id)

 is Favorite Favorite)
    {
        db.Favorites.Remove(Favorite);
        await db.SaveChangesAsync();
        return Results.Ok(Favorite);
    }
    return Results.NotFound();
});
app.Run();