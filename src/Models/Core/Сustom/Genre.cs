using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Сustom
{
    public class Genre
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("image")]
        public Image? Image { get; set; }

        [JsonProperty("total_releases")]
        public int? TotalReleases { get; set; }
    }
}
