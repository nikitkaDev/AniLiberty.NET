using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Base
{
    public class Optimized
    {
        [JsonProperty("preview")]
        public string Preview { get; set; } = string.Empty;

        [JsonProperty("thumbnail")]
        public string Thumbnail {  get; set; } = string.Empty;
    }
}
