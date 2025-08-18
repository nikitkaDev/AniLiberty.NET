using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Сustom
{
    public class User
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; } = string.Empty;

        [JsonProperty("avatar")]
        public Avatar? Avatar { get; set; }
    }
}
