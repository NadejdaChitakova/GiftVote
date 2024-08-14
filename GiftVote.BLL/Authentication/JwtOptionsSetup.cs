using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace GiftVote.BLL.Authentication
{
    public class JwtOptionsSetup(
        IConfiguration configuration) : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";

        public void Configure(JwtOptions options)
        {
            configuration.GetSection(SectionName).Bind(options);
        }
    }
}
