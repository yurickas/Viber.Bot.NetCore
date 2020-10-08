using System.Collections.Generic;
using Newtonsoft.Json;

namespace Viber.Bot.NetCore.Models
{
    public class ViberWebhookResponse : ViberApiResponseBase
    {
        [JsonProperty("event_types")]
        public ICollection<string> EventTypes { get; set; }
    }
}