using AniLiberty.NET.Models.Entities.Releases;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Entities.Franchises
{
    public class FranchiseReleases
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("sort_order")]
        public int? SorterOrder { get; set; }

        [JsonProperty("release_id")]
        public int ReleaseId { get; set; }

        [JsonProperty("franchise_id")]
        public string FranchiseId { get; set; } = string.Empty;

        [JsonProperty("release")]
        public List<Release>? Releases { get; set; }
        
    }
}
