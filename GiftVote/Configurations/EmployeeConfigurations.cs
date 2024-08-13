using GiftVote.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftVote.Data.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .HasMaxLength(200);

            builder.Property(x => x.UserName)
                .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
