using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Base
{
    public class Origin
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("type")]
        public TypeReference? Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("is_announce")]
        public bool IsAnnounce { get; set; }
    }
}
