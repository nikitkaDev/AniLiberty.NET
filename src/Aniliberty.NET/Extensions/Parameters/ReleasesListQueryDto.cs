namespace AniLiberty.NET.Extensions.Parameters
{
    public class ReleasesListQueryDto
    {
        public List<int>? Ids { get; set; }
        public List<string>? Aliases { get; set; }
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}
