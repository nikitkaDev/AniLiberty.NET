using AniLiberty.NET.src.Models.Core.Base;
using AniLiberty.NET.src.Models.Core.Сustom;
using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Entities.Members
{
    public class TorrentMember
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("role")]
        public Role? Role { get; set; }

        [JsonProperty("user")]
        public User? User { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; } = string.Empty;

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; } = string.Empty;
    }
}
