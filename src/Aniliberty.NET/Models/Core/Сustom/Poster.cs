using AniLiberty.NET.Models.Core.Base;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Сustom
{
    public class Poster
    {
        [JsonProperty("preview")]
        public string Preview { get; set; } = string.Empty;

        [JsonProperty("thumbnail")] 
        public string Thumbnail { get; set; } = string.Empty;

        [JsonProperty("optimized")]
        public Optimized? Optimized { get; set; }
    }
}
