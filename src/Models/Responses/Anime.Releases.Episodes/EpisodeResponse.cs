using AniLiberty.NET.src.Models.Core.Base;
using AniLiberty.NET.src.Models.Core.Сustom;
using AniLiberty.NET.src.Models.Entities.Releases;
using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Responses.Anime.Releases.Episodes
{
    public class EpisodeResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("ordinal")]
        public string Ordinal { get; set; } = string.Empty;

        [JsonProperty("ending")]
        public Ending? Ending { get; set; }

        [JsonProperty("opening")]
        public Opening? Opening { get; set; }

        [JsonProperty("preview")]
        public Preview? Preview { get; set; }

        [JsonProperty("hls_480")]
        public string Hls480 { get; set; } = string.Empty;

        [JsonProperty("hls_720")]
        public string Hls720 { get; set; } = string.Empty;

        [JsonProperty("hls_1080")]
        public string Hls1080 { get; set; } = string.Empty;

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("rutube_id")]
        public string RutubeId { get; set; } = string.Empty;

        [JsonProperty("youtube_id")]
        public string YoutubeId { get; set; } = string.Empty;

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; } = string.Empty;

        [JsonProperty("sort_order")]
        public int? SortOrder { get; set; }

        [JsonProperty("release_id")]
        public int? ReleaseId { get; set; }

        [JsonProperty("name_english")]
        public string EnglishName { get; set; } = string.Empty;

        [JsonProperty("release")]
        public ReleasesWithEpisodes? Release {  get; set; }

    }
}
