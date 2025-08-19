using AniLiberty.NET.Models.Core.Сustom;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Entities.Franchises
{
    public class Franchise
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("name_english")]
        public string? EnglishName { get; set; } = string.Empty;

        [JsonProperty("image")]
        public Image? Image { get; set; }

        [JsonProperty("rating")]
        public float? Rating { get; set; }

        [JsonProperty("last_year")]
        public int? LastYear { get; set; }

        [JsonProperty("first_year")]
        public int? FirstYear {  get; set; }

        [JsonProperty("total_releases")]
        public int? TotalReleases { get; set; }

        [JsonProperty("total_episodes")]
        public int? TotalEpisodes { get; set; }

        [JsonProperty("total_duration")]
        public string TotalDuration { get; set; } = string.Empty;

        [JsonProperty("total_duration_in_seconds")]
        public int? TotalDurationInSeconds { get; set; }
    }
}
