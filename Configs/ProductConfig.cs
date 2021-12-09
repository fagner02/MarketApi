using Microsoft.EntityFrameworkCore;
using market_api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace market_api.Configs {
    public class ProductConfig : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductId).HasMaxLength(36);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).HasPrecision(20, 2);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.HasOne<Category>()
            .WithMany().HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}