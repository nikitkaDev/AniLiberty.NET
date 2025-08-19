using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Shorts
{
    public class SortingShort
    {
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
