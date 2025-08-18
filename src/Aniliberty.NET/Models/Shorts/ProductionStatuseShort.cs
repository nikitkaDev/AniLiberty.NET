using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Shorts
{
    public class ProductionStatuseShort
    {
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
