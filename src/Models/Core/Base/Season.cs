using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Base
{
    public class Season
    {
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
