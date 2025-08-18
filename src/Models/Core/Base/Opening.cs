using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Base
{
    public class Opening
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("stop")]
        public int? Stop { get; set; }
    }
}
