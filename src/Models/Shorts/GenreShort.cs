using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Shorts
{
    public class GenreShort
    {

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

    }
}
