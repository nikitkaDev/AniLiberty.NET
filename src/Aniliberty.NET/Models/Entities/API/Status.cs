using AniLiberty.NET.Models.Core.Base;
using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Entities.API
{
    public class Status
    {
        [JsonProperty("request")]
        public Request? Request { get; set; }

        [JsonProperty("is_alive")]
        public bool IsAlive { get; set; }

        [JsonProperty("available_api_endpoints")]
        public List<string>? AvaliableApiEndpoints { get; set; } 
    }
}
