using AniLiberty.NET.Client;
using AniLiberty.NET.Models.Shorts;

namespace AniTest
{
    public class AnilibertyTest
    {
        [Fact]
        public async Task GetReleasesByFilterAsync_ReturnsExpectedReleases()
        {
            AnilibertyClient anilibertyClient = new(new());

            var result = await anilibertyClient.GetReleasesByFilterAsync(new() { Page = 5});

            Assert.NotNull(result);
            Assert.Equal(1710, result.Meta?.Pagination?.Total);
            Assert.Equal(10, result.Meta?.Pagination?.Count);
            Assert.Equal(10, result.Meta?.Pagination?.PerPage);
            Assert.Equal(5, result.Meta?.Pagination?.CurrentPage);
            Assert.Equal(171, result.Meta?.Pagination?.TotalPages);
        }

        [Fact]
        public async Task GetAgeRatingsAsync_ReturnsExpected()
        {
            AnilibertyClient anilibertyClient = new(new());

            List<AgeRatingShort>? result = await anilibertyClient.GetAgeRatingsAsync();
            string par = "";

            if (result != null)
            {
                foreach (var item in result)
                {
                    par += item.Value;
                }
            }

            Assert.NotNull(result);
            Assert.Equal("R0_PLUSR6_PLUSR12_PLUSR16_PLUSR18_PLUS", par);
        }
    }
}