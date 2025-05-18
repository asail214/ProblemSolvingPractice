using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoharLibrary.Models;

namespace SoharLibrary.Configuration
{
    public class BorrowConfiguration : IEntityTypeConfiguration<Borrow>
    {
        public void Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Member)
                   .WithMany(m => m.Borrows)
                   .HasForeignKey(b => b.MemberId)
                   .HasPrincipalKey(m => m.MemberId);

            builder.HasOne(b => b.Book)
                   .WithMany(book => book.Borrows)
                   .HasForeignKey(b => b.ISBN)
                   .HasPrincipalKey(book => book.ISBN);
        }
    }


}
