using AniLiberty.NET.Models.Core.Base;
using AniLiberty.NET.Models.Entities.Members;
using AniLiberty.NET.Models.Entities.Releases;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Responses.Anime.Torrents
{
    public class TorrentResponse
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        [JsonProperty("size")]
        public int? Size { get; set; }

        [JsonProperty("type")]
        public TypeReference? Type { get; set; }

        [JsonProperty("color")]
        public Color? Color { get; set; }

        [JsonProperty("codec")]
        public Codec? Codec { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("quality")]
        public Quality? Quality { get; set; }

        [JsonProperty("magnet")]
        public string Magnet { get; set; } = string.Empty;

        [JsonProperty("filename")]
        public string Filename { get; set; } = string.Empty;

        [JsonProperty("seeders")]
        public int? Seeders { get; set; }

        [JsonProperty("bitrate")]
        public int? Bitrate { get; set; }

        [JsonProperty("leechers")]
        public int? Leechers { get; set; }

        [JsonProperty("sort_order")]
        public int? SortOrder { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; } = string.Empty;

        [JsonProperty("is_hardsub")]
        public bool IsHardsub { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; } = string.Empty;

        [JsonProperty("completed_times")]
        public int? CompetedTimes { get; set; }

        [JsonProperty("torrent_members")]
        List<TorrentMember>? Members { get; set; }

        [JsonProperty("release")]
        public Release? Release { get; set; }
    }
}
