using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Base
{
    public class Ending
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("stop")]
        public int? Stop{ get; set; }
    }
}
