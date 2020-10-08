using System;
using System.Net.Http;
using Refit;
using Viber.Bot.NetCore.Infrastructure;
using Viber.Bot.NetCore.RestApi;

namespace Viber.Bot.NetCore.Middleware
{
    public static class ViberClient
    {
        public static IViberBotApi RegisterViberApi(ViberBotConfiguration conf)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"https://chatapi.viber.com/pa/");
            client.DefaultRequestHeaders.Add("X-Viber-Auth-Token", conf.Token);

            return RestService.For<IViberBotApi>(client);
        }
    }
}