using Newtonsoft.Json;

namespace Viber.Bot.NetCore.Models
{
    public static class ViberUser
    {
        public class UserBase
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("avatar")]
            public string Avatar { get; set; }
        }

        public class User: UserBase
        {
			/// <summary>
            /// Unique Viber user id.
            /// </summary>
            [JsonProperty("id")]
            public string Id { get; set; }

            /// <summary>
            /// User’s 2 letter country code.
            /// </summary>
            [JsonProperty("country")]
            public string Country { get; set; }

            /// <summary>
            /// User’s phone language.
            /// </summary>
            [JsonProperty("language")]
            public string Language { get; set; }

            /// <summary>
            /// Max API version, matching the most updated user’s device.
            /// </summary>
            [JsonProperty("api_version")]
            public double? ApiVersion { get; set; }
		}

	}
}