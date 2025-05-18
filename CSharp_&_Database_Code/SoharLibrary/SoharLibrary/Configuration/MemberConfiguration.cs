using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoharLibrary.Models;

namespace SoharLibrary.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.MemberId).IsRequired();

            builder.HasIndex(m => m.MemberId).IsUnique();

            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        }
    }
}
