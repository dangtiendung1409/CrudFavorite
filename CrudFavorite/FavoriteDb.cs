using System;
using Microsoft.EntityFrameworkCore;


namespace CrudFavorite
{
	public class FavoriteDb : DbContext
    {
        public FavoriteDb(DbContextOptions<FavoriteDb> options) : base(options) { }
        public DbSet<Favorite> Favorites => Set<Favorite>();
    }
}



