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
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            return services;
        }
        }
}
