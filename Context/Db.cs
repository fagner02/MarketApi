using Microsoft.EntityFrameworkCore;
using market_api.Models;
using market_api.Configs;

namespace market_api.Context {
    public class Db : DbContext {
        public Db(DbContextOptions<Db> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Category>(new CategoryConfig().Configure);
            builder.Entity<Product>(new ProductConfig().Configure);
        }
    }

}