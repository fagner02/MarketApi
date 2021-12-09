using Microsoft.EntityFrameworkCore;
using market_api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace market_api.Configs {
    public class CategoryConfig : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.ToTable("Categories");
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId).HasMaxLength(36);
            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}