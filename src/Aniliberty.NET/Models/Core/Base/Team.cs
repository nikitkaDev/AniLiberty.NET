using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Base
{
    public class Team
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("sort_order")]
        public int? SortOrder { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
