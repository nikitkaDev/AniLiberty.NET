using AniLiberty.NET.Models.Core.Base;
using AniLiberty.NET.Models.Core.Сustom;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Responses.Teams
{
    public class AniUserResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("nickname")]
        public string Nickname { get; set; } = string.Empty;

        [JsonProperty("is_intern")]
        public bool IsIntern { get; set; }

        [JsonProperty("sort_order")]
        public int? SortOrder { get; set; }

        [JsonProperty("is_vacation")]
        public bool IsVacation { get; set; }

        [JsonProperty("team")]
        public Team? Team { get; set; }

        [JsonProperty("user")]
        public User? User { get; set; }

        [JsonProperty("roles")]
        public List<TeamRole>? Roles { get; set; }
    }
}
