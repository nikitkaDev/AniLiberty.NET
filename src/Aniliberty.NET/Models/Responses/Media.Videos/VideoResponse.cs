using AniLiberty.NET.Models.Core.Base;
using AniLiberty.NET.Models.Core.Сustom;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Responses.Media.Videos
{
    public class VideoResponse
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("views")]
        public int? Views { get; set; }

        [JsonProperty("image")]
        public Image? Image { get; set; }

        [JsonProperty("comments")]
        public int? Comments { get; set; }

        [JsonProperty("video_id")]
        public string? VideoId { get; set; } = string.Empty;

        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; } = string.Empty;

        [JsonProperty("updated_at")]
        public string? UpdatedAt { get; set; } = string.Empty;

        [JsonProperty("is_announce")]
        public bool IsAnnounce { get; set; }

        [JsonProperty("origin")]
        public Origin? Origin { get; set; }

       
    }
}
