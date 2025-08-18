using AniLiberty.NET.src.Extensions.Parameters;
using AniLiberty.NET.Domain.Structs;
using Microsoft.Extensions.Logging;

namespace AniLiberty.NET.src.Extensions.Builders
{
    public class QueryBuilder
    {
        public static string Build(ReleaseQueryDto parametrs, ILogger<QueryBuilder>? logger = null)
        {
            try
            {
                List<string> query = [];

                query.Add($"page={parametrs.Page}");
                query.Add($"limit={parametrs.ReleaseLimitOnPage}");
                query.Add($"f[years][from_year]={parametrs.MinYearOfRelease}");
                query.Add($"f[years][to_year]={parametrs.MaxYearOfRelease}");

                if (!string.IsNullOrEmpty(parametrs.SearchString)) query.Add($"f[search]={parametrs.SearchString}");

                if (parametrs.ReleaseType != ReleasesType.None) query.Add($"f[types]={parametrs.ReleaseType}");
                if (parametrs.SeasonType != SeasonType.None) query.Add($"f[seasons]={parametrs.SeasonType}");
                if (parametrs.SortingType != SortingType.None) query.Add($"f[sorting]={parametrs.SortingType}");
                if (parametrs.AgeRatingType != AgeRatingType.None) query.Add($"f[age_ratings]={parametrs.AgeRatingType}");
                if (parametrs.PublishStatusType != PublishStatusType.None) query.Add($"f[publish_statuses]={parametrs.PublishStatusType}");
                if (parametrs.ProductionStatusType != ProductionStatusType.None) query.Add($"f[production_statuses]={parametrs.ProductionStatusType}");

                return string.Join("&", query);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Ошибка заполнения параметров");
                return string.Empty;
            }
            
        }

        public static string Build(ReleasesListQueryDto parametrs, ILogger<QueryBuilder>? logger = null)
        {
            try
            {
                List<string> query = [];

                if (parametrs.Ids == null && parametrs.Aliases == null) { throw new Exception("Хотя бы один из двух параметров Ids или Aliases должен быть не null."); }
                if (parametrs.Ids != null) { query.Add($"ids={string.Join(",", parametrs.Ids)}"); }
                if (parametrs.Aliases != null) { query.Add($"aliases={string.Join(",", parametrs.Aliases)}"); }

                query.Add($"page={parametrs.Page}");
                query.Add($"limit={parametrs.Limit}");

                if (query.Count == 0) return string.Empty;
                return string.Join("&", query);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Ошибка заполнения параметров");
                return string.Empty;
            }
        }
    }
}
