using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Core.Base
{
    public class Sponsor
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description {  get; set; } = string.Empty;

        [JsonProperty("url_title")]
        public string UrlTitle {  get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url {  get; set; } = string.Empty;
    }
}
