using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GiftVote.Data.Context
{
    public class IdentityDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public IdentityDbContext(DbContextOptions options,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public IdentityDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string? connectionString = _configuration["ConnectionStrings:Database"];

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
