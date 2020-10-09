using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Viber.Bot.NetCore.Infrastructure;
using Viber.Bot.NetCore.Models;

namespace Viber.Bot.NetCore.Middleware
{
    public static class ViberMiddlewareExtentions
    {
        public static IServiceCollection AddViberBotApi(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("ViberBot");

            services.AddViberBotApi(a =>
            {
                a.Token = section["Token"];
                a.Webhook = section["Webhook"];
            });

            return services;
        }

        public static IServiceCollection AddViberBotApi(this  IServiceCollection services, Action<ViberBotConfiguration> action)
        {
            ViberBotConfiguration conf = new ViberBotConfiguration();

            action.Invoke(conf);

            var bot = ViberClient.RegisterViberApi(conf);

            bot.SetWebHookAsync(new ViberWebHook.WebHookRequest(conf.Webhook));

            services.AddSingleton(bot);

            return services;
        }
    }
}