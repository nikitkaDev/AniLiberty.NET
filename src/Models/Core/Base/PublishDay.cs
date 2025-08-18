using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Core.Base
{
    public class PublishDay
    {
        [JsonProperty("value")]
        public int? Value { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
