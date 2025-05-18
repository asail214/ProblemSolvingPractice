using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoharLibrary.Models;

namespace SoharLibrary.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.ISBN).IsRequired();

            builder.HasIndex(b => b.ISBN).IsUnique();

            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.IsAvailable).HasDefaultValue(true);
        }
    }
}
