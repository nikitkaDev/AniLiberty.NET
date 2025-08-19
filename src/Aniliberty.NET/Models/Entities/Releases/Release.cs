using AniLiberty.NET.Models.Core.Base;
using AniLiberty.NET.Models.Core.Сustom;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Entities.Releases
{
    public class Release
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("type")]
        public TypeReference? Type { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("name")]
        public Name? Name { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; } = string.Empty;

        [JsonProperty("season")]
        public Season? Season { get; set; }

        [JsonProperty("poster")]
        public Poster? Poster { get; set; }

        [JsonProperty("fresh_at")]
        public string FreshAt { get; set; } = string.Empty;

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = string.Empty;

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set;} = string.Empty;

        [JsonProperty("is_ongoing")]
        public bool IsOngoing { get; set; }

        [JsonProperty("age_rating")]
        public AgeRating? AgeRating { get; set; }

        [JsonProperty("publish_day")]
        public PublishDay? PublishDay { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("notification")]
        public string Notification { get; set; } = string.Empty;

        [JsonProperty("episodes_total")]
        public int? EpisodesTotal { get; set; }

        [JsonProperty("external_player")]
        public string ExternalPlayer { get; set; } = string.Empty;

        [JsonProperty("is_in_production")]
        public bool IsInProduction { get; set; }

        [JsonProperty("is_blocked_by_geo")]
        public bool IsBlockedByGeo { get; set; }

        [JsonProperty("is_blocked_by_copyrights")]
        public bool IsBlockedByCopyrights { get; set; }

        [JsonProperty("added_in_users_favorites")]
        public int? AddedInUsersFavorites { get; set; }

        [JsonProperty("average_duration_of_episode")]
        public int? AverageDurationOfEpisode { get; set; }

        [JsonProperty("added_in_planned_collection")]
        public int? AddedInPlannedCollection { get; set; }

        [JsonProperty("added_in_watched_collection")]
        public int? AddedInWatchedCollection { get; set; }

        [JsonProperty("added_in_watching_collection")]
        public int? AddedInWatchingCollection { get; set; }

        [JsonProperty("added_in_postponed_collection")]
        public int? AddedInPostponedCollection { get; set; }

        [JsonProperty("added_in_abandoned_collection")]
        public int? AddedInAbandonedCollection { get; set; }
    }
}
