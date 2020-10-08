using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Viber.Bot.NetCore.Middleware
{
    public static class ViberMiddlewareExtentions
    {
        public static IServiceCollection AddViberBotApi(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}