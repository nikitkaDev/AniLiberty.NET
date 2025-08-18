using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Base
{
    public class Ending
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("stop")]
        public int? Stop{ get; set; }
    }
}
