using GiftVote.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftVote.Data.Configurations
{
    internal class BallotConfigurations : IEntityTypeConfiguration<Ballot>
    {
        public void Configure(EntityTypeBuilder<Ballot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.HasOne(x => x.Creator)
                .WithMany(x => x.CreatedBallots)
                .HasForeignKey(x => x.CreatorId);

            builder.HasOne(x => x.GiftReceiver)
                .WithMany(x => x.EmployeeBallots)
                .HasForeignKey(x => x.GiftReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
