using System.Threading.Tasks;
using Refit;
using Viber.Bot.NetCore.Models;

namespace Viber.Bot.NetCore.RestApi
{
    public interface IViberBotApi
    {
        [Post("/set_webhook")]
        Task<ApiResponse<ViberWebHook.ViberWebHookResponse>> SetWebHookAsync([Body] ViberWebHook.WebHookRequest request);
    }
}