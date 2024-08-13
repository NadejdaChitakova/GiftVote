using GiftVote.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftVote.Data.Configurations
{
    internal class VoteConfigurations :IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Gift)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.GiftId);

            builder.HasOne(x => x.Voter)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.VoterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Ballot)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.BallotId);
        }
    }
}
