using GiftVote.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftVote.Data.Configurations
{
    internal class GiftConfigurations :IEntityTypeConfiguration<Gifts>
    {
        public void Configure(EntityTypeBuilder<Gifts> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

builder.HasMany(x=> x.Votes)
                .WithOne(x=> x.Gift)
                .HasForeignKey(x=> x.GiftId);
        }
    }
}
