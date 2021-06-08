using Birthday.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Birthday.EntityConfiguration
{
    public class VotingConfiguration : IEntityTypeConfiguration<Voting>
    {
        public void Configure(EntityTypeBuilder<Voting> builder)
        {
            builder.HasKey(v => v.VotingId);
            builder.HasMany(v => v.VotingDetails);
        }
    }
}
