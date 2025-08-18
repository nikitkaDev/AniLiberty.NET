using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Shorts
{
    public class PublishStatuseShort
    {
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
