using Newtonsoft.Json;
using Viber.Bot.NetCore.Infrastructure;

namespace Viber.Bot.NetCore.Models
{
    public static class ViberResponse
    {
        public abstract class ViberApiResponseBase
        {
            [JsonProperty("status")]
            public ViberErrorCode Status { get; set; }

            [JsonProperty("status_message")]
            public string StatusMessage { get; set; }
        }

        public class SendMessageResponse: ViberApiResponseBase
        {
            /// <summary>
            /// Unique id of the message.
            /// </summary>
            [JsonProperty("message_token")]
            public long MessageToken { get; set; }
        }
    }

    
}