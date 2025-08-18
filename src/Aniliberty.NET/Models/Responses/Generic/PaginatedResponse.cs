using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Responses.Generic
{
    public class PaginatedResponse<T>
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; } = [];

        [JsonProperty("meta")]
        public Meta? Meta { get; set; }
    }

    public class Meta
    {
        [JsonProperty("pagination")]
        public Pagination? Pagination { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("current_page")]
        public int? CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }

        [JsonProperty("links")]
        public PaginationLinks? Links { get; set; }
    }

    public class PaginationLinks
    {
        [JsonProperty("previous")]
        public string? Previous { get; set; }

        [JsonProperty("next")]
        public string? Next { get; set; }
    }
}