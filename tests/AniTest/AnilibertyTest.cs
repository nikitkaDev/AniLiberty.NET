using AniLiberty.NET.Client;
using AniLiberty.NET.Models.Shorts;

namespace AniTest
{
    public class AnilibertyTest
    {
        [Fact]
        public async Task GetReleasesByFilterAsync_ReturnsExpected()
        {
            AnilibertyClient anilibertyClient = new(new HttpClient());

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
            AnilibertyClient anilibertyClient = new(new HttpClient());

            List<AgeRatingShort>? result = await anilibertyClient.GetAgeRatingsAsync();
            string value = "";

            if (result != null)
            {
                foreach (var item in result)
                {
                    value += item.Value;
                }
            }

            Assert.NotNull(result);
            Assert.Equal("R0_PLUSR6_PLUSR12_PLUSR16_PLUSR18_PLUS", value);
        }

        [Fact]
        public async Task GetGenresAsync_ReturnsExpected()
        {
            AnilibertyClient anilibertyClient = new(new HttpClient());

            List<GenreShort>? result = await anilibertyClient.GetGenresAsync();
            string value = "";
            
            if (result != null)
            {
                foreach(var item in result)
                {
                    value += item.Name;
                }
            }

            Assert.NotNull(result);
            Assert.Equal("Ѕоевые искусства¬ампиры√аремƒемоныƒетектив" +
                "ƒзЄсейƒрама»гры»секай»сторический иберпанк омеди€ћаги€ћехаћистика" +
                "ћузыкаѕароди€ѕовседневностьѕриключени€ѕсихологическое–омантика—верхъестественное" +
                "—Єдзе—Єдзе-ай—ейнен—Єнен—порт—упер сила“риллер”жасы‘антастика‘энтезиЎколаЁкшенЁтти", value);
        }

    }
}