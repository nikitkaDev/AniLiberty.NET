using AniLiberty.NET.src.Models.Core.Сustom;
using AniLiberty.NET.src.Models.Entities.Releases;
using Newtonsoft.Json;

namespace AniLiberty.NET.src.Models.Responses.Media.Promotions
{
    public class PromotionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("url_label")]
        public string UrlLabel { get; set; } = string.Empty;

        [JsonProperty("image")]
        public Image? Image { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("is_ad")]
        public bool IsAd { get; set; }

        [JsonProperty("ad_erid")]
        public string AdErid { get; set; } = string.Empty;

        [JsonProperty("ad_origin")]
        public string AdOrigin { get; set; } = string.Empty;

        [JsonProperty("release")]
        public Release? Release { get; set; }

        [JsonProperty("has_overlay")]
        public bool HasOverlay { get; set; }
    }
}
