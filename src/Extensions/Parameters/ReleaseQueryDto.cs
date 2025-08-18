using AniLiberty.NET.Domain.Structs;

namespace AniLiberty.NET.src.Extensions.Parameters 
{
    public class ReleaseQueryDto
    {
        public int Page { get; set; } = 1;
        public int ReleaseLimitOnPage { get; set; } = 10;
        public ReleasesType ReleaseType { get; set; } = ReleasesType.None;
        public SeasonType SeasonType { get; set; } = SeasonType.None;
        public SortingType SortingType { get; set; } = SortingType.None;
        public AgeRatingType AgeRatingType { get; set; } = AgeRatingType.None;
        public PublishStatusType PublishStatusType { get; set; } = PublishStatusType.None;
        public ProductionStatusType ProductionStatusType { get; set; } = ProductionStatusType.None;
        public int MinYearOfRelease { get; set; } = 0;
        public int MaxYearOfRelease { get; set; } = 0;
        public string SearchString { get; set; } = string.Empty;
    }
}