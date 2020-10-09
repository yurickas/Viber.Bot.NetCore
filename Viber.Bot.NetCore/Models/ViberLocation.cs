using Newtonsoft.Json;

namespace Viber.Bot.NetCore.Models
{
    public class ViberLocation
    {
        /// <summary>
        /// Longitude of the <see cref="ViberLocation"/>.
        /// </summary>
        [JsonProperty("lon")]
        public double Lon { get; set; }

        /// <summary>
        /// Latitude of the <see cref="ViberLocation"/>.
        /// </summary>
        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}