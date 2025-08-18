using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Base
{
    public class AgeRating
    {
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("is_adult")]
        public bool IsAdult { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
