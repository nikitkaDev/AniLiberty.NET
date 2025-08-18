using AniLiberty.NET.Models.Entities.Episodes;
using AniLiberty.NET.Models.Entities.Releases;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Responses.Anime.Releases.Schedule
{
    public class ScheduleReleaseResponse
    {
        [JsonProperty("release")]
        public Release? Release { get; set; }

        [JsonProperty("full_season_is_released")]
        public bool FullSeasonIsReleased { get; set; } 

        [JsonProperty("published_release_episode")]
        public Episode? Episode { get; set; }

        [JsonProperty("next_release_episode_number")]
        public int? NextReleaseEpisodeNumber { get; set; }
    }
}
