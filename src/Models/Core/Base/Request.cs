using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Base
{
    public class Request
    {
        [JsonProperty("ip")]
        public string Ip { get; set; } = string.Empty;

        [JsonProperty("country")]
        public string Country { get; set; } = string.Empty;

        [JsonProperty("iso_code")]
        public string IsoCode { get; set; } = string.Empty;

        [JsonProperty("timezone")]
        public string Timezone { get; set; } = string.Empty;
    }
}
