using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Base
{
    public class Name
    {
        [JsonProperty("main")]
        public string Main { get; set; } = string.Empty;

        [JsonProperty("english")]
        public string English { get; set; } = string.Empty;

        [JsonProperty("alternative")]
        public string Alternative {  get; set; } = string.Empty;
    }
}
