using AniLiberty.NET.src.Models.Core.Base;
using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Сustom
{
    public class Preview
    {
        [JsonProperty("preview")]
        public string PropertyPreview {  get; set; } = string.Empty;

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; } = string.Empty;

        [JsonProperty("optimized")]
        public Optimized? Optimized { get; set; }
    }
}
