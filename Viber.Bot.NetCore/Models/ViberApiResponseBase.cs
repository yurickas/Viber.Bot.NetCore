using Newtonsoft.Json;
using Viber.Bot.NetCore.Infrastructure;

namespace Viber.Bot.NetCore.Models
{
    public abstract class ViberApiResponseBase
    {
		[JsonProperty("status")]
        public ViberErrorCode Status { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
	}
}