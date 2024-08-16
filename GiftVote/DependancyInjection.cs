using GiftVote.Data.Context;
using GiftVote.Data.Repositories;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GiftVote.Data
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<IdentityDbContext>(options => { options.UseSqlServer(connectionString); });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IBallotRepository, BallotRepository>();

            return services;
        }
    }
}
