using Newtonsoft.Json;

namespace AniLiberty.NET.Models.Responses.Generic
{
    public class PaginatedScheduleResponse<T>
    {
        [JsonProperty("today")]
        public List<T>? Today { get; set; }

        [JsonProperty("tomorrow")]
        public List<T>? Tomorrow {  set; get; }

        [JsonProperty("yesterday")]
        public List<T>? Yesterday { set; get; }
    }
}
