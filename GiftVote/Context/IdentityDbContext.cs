using Microsoft.EntityFrameworkCore;

namespace GiftVote.Data.Context
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions options): base(options) { }

        public IdentityDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=giftVote; user id=sa; password=Na!12345678;  TrustServerCertificate=True;");
        }
    }
}
