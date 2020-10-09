using System.Collections.Generic;
using Newtonsoft.Json;
using Viber.Bot.NetCore.Infrastructure;

namespace Viber.Bot.NetCore.Models
{
    public static class ViberWebHook
    {
        public class ViberWebHookResponse : ViberApiResponseBase
        {
            [JsonProperty("event_types")]
            public ICollection<string> EventTypes { get; set; }
        }

        public class WebHookRequest
        {
            [JsonProperty("url")]
            public string Url { get; set; }
            [JsonProperty("event_types")]
            public List<string> EventTypes { get; set; }
            [JsonProperty("send_name")]
            public bool SendName { get; set; }
            [JsonProperty("send_photo")]
            public bool SendPhoto { get; set; }

            public WebHookRequest()
            {
                
            }

            public WebHookRequest(string url)
            {
                Url = url;
                EventTypes = new List<string>();
                SendName = false;
                SendPhoto = false;
            }
        }
    }

}