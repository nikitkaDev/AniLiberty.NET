using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Responses.Anime.Releases
{
    public class TimecodesResponse
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("time")]
        public float? Time { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("is_watched")]
        public bool IsWatched { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; } = string.Empty;

        [JsonProperty("release_episode_id")]
        public string ReleaseEpisodeId { get; set; } = string.Empty;
    }
}
