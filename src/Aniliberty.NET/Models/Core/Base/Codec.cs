using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Base
{
    public class Codec
    {
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("label_color")]
        public string LabelColor {  get; set; } = string.Empty;

        [JsonProperty("label_is_visible")]
        public bool LabelIsVisible { get; set; }
    }
}
