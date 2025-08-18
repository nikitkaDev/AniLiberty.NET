using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Base
{
    public class TeamRole
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("color")]
        public string Color { get; set; } = string.Empty;

        [JsonProperty("sort_order")]
        public int? SortOrder { get; set; }

    }
}
