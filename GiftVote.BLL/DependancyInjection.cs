using GiftVote.BLL.AutoMapper;
using GiftVote.BLL.Contracts;
using GiftVote.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GiftVote.BLL
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(EmployeeMapper));
            services.AddAutoMapper(typeof(BallotMapper));

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IBallotService, BallotService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            return services;
        }
        }
}
