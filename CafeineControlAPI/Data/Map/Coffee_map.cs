using CaffeineControlAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaffeineControlAPI.Data.Map
{
    public class Coffee_map : IEntityTypeConfiguration<Coffee>
    {
        public void Configure(EntityTypeBuilder<Coffee> builder)
        {
            builder.ToTable("coffee");

            builder.HasKey(c => c.Code);

            builder.Property(c => c.Code).HasColumnName("code").HasColumnType("varchar").HasMaxLength(3).IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(c => c.CaffeineLevel).HasColumnName("caffeine_level").HasColumnType("numeric").IsRequired();
        }
    }
}
