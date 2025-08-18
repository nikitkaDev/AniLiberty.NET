using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Base
{
    public class Quality
    {
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
