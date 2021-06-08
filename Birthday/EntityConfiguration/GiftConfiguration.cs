using Birthday.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Birthday.EntityConfiguration
{
    public class GiftConfiguration : IEntityTypeConfiguration<Gift>
    {
        public void Configure(EntityTypeBuilder<Gift> builder)
        {
            builder.HasKey(g => g.GiftId);
            builder.Property(g => g.GiftName).HasMaxLength(50);
        }
    }
}
