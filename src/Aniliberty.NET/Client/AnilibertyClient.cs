using System.Xml;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using AniLiberty.NET.Extensions.Parameters;
using AniLiberty.NET.Extensions.Builders;
using AniLiberty.NET.Models.Shorts;
using AniLiberty.NET.Models.Core.Base;
using AniLiberty.NET.Models.Core.Сustom;
using AniLiberty.NET.Models.Entities.API;
using AniLiberty.NET.Models.Entities.Franchises;
using AniLiberty.NET.Models.Entities.Members;
using AniLiberty.NET.Models.Entities.Releases;
using AniLiberty.NET.Models.Responses.Anime.Franchises;
using AniLiberty.NET.Models.Responses.Anime.Releases;
using AniLiberty.NET.Models.Responses.Anime.Releases.Episodes;
using AniLiberty.NET.Models.Responses.Anime.Releases.Schedule;
using AniLiberty.NET.Models.Responses.Anime.Torrents;
using AniLiberty.NET.Models.Responses.Generic;
using AniLiberty.NET.Models.Responses.Media.Promotions;
using AniLiberty.NET.Models.Responses.Media.Videos;
using AniLiberty.NET.Models.Responses.Teams;
using Newtonsoft.Json;
namespace AniLiberty.NET.Client
{
    public class AnilibertyClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AnilibertyClient>? _logger;
        
        /// <summary>
        /// Точка входа в Aniliberty.NET
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="baseAdress">URL сервера</param>
        /// <param name="logger"></param>
        public AnilibertyClient(
            HttpClient httpClient,
            string? baseAdress = null,
            ILogger<AnilibertyClient>? logger = null)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseAdress is null ? new Uri("https://anilibria.top/api/v1/") : new Uri(baseAdress);
        }

        public AnilibertyClient(
            ILogger<AnilibertyClient>? logger = null,
            string? baseAdress = null)
        {
            _logger = logger;
            _httpClient = new()
            {
                BaseAddress = baseAdress is null ? new Uri("https://anilibria.top/api/v1/") : new Uri(baseAdress)
            };
        }

        #region ExtensionMethods
        private async Task<T?> GetFromAPIAsync<T>(string path, T fallback, CancellationToken token = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(path, token).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode) { return fallback; }

            return JsonConvert.DeserializeObject<T>(
                await response.Content.ReadAsStringAsync(token));
        }
        private async Task<List<T>?> GetDirectoryListAsync<T>(string endpoint, CancellationToken token = default)
        {
            return await SafeExecuteAsync(async () =>
            {
                using HttpResponseMessage response = await _httpClient.GetAsync($"anime/catalog/references/{endpoint}", token).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode) { return new List<T>(); }

                return JsonConvert.DeserializeObject<List<T>>(
                    await response.Content.ReadAsStringAsync(token));
            });
        }
        private async Task<T?> SafeExecuteAsync<T>(Func<Task<T?>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Ошибка при выполнения запрос к API");
                return default;
            }
        }
        #endregion

        #region Anime.Catalog

        /// <summary>
        /// Получает список отфильтрованных релизов.
        /// </summary>
        /// <param name="queryParametrs">Фильтр</param>
        /// <returns>Объект <see cref="PaginatedResponse{T}"/>, содержащий коллекцию релизов и мета данные запроса, соответствующих фильтру <see cref="ReleaseQueryDto"/>.</returns>
        public Task<PaginatedResponse<Release>?> GetReleasesByFilterAsync(ReleaseQueryDto? queryParametrs = null) => 
            SafeExecuteAsync(() => GetFromAPIAsync(
                queryParametrs is null
                    ? $"anime/catalog/releases"
                    : $"anime/catalog/releases?{QueryBuilder.Build(queryParametrs)}",
                new PaginatedResponse<Release>() { Data = new List<Release>() }));
        #endregion

        #region Anime.Catalog.Directories
        
        /// <summary>
        /// Возвращает список возможных возрастных рейтингов в каталоге.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="AgeRatingShort"/>, содержащий возрастные рейтинги.</returns>
        public Task<List<AgeRatingShort>?> GetAgeRatingsAsync(CancellationToken token = default) => GetDirectoryListAsync<AgeRatingShort>("age-ratings", token);

        /// <summary>
        /// Возвращает список всех жанров в каталоге.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="GenreShort"/>, содержащий жанры аниме.</returns>
        public Task<List<GenreShort>?> GetGenresAsync(CancellationToken token = default) => GetDirectoryListAsync<GenreShort>("genres", token);

        /// <summary>
        /// Возвращает список возможных статусов озвучки релиза в каталоге.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="ProductionStatuseShort"/>, содержащий статусы озвучки релиза.</returns>
        public Task<List<ProductionStatuseShort>?> GetProductionStatusesAsync(CancellationToken token = default) => GetDirectoryListAsync<ProductionStatuseShort>("production-statuses", token);

        /// <summary>
        /// Возвращает список возможных статусов выхода релиза в каталоге.
        /// </summary>
        /// <param name="token">Токен отмена</param>
        /// <returns>Список объектов <see cref="ProductionStatuseShort"/>, содержащий статусы выхода релиза.</returns>
        public Task<List<PublishStatuseShort>?> GetPublishStatusesAsync(CancellationToken token = default) => GetDirectoryListAsync<PublishStatuseShort>("publish-statuses", token);

        /// <summary>
        /// Возвращает список возможных сезонов релизов в каталоге.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="SeasonShort"/>, содержащий сезоны релизов.</returns>
        public Task<List<SeasonShort>?> GetSeasonsAsync(CancellationToken token = default) => GetDirectoryListAsync<SeasonShort>("seasons", token);

        /// <summary>
        /// Возвращает список возможных типов сортировок в каталоге.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="SortingShort"/>, содержащий типы сортировок.</returns>
        public Task<List<SortingShort>?> GetSortingAsync(CancellationToken token = default) => GetDirectoryListAsync<SortingShort>("sorting", token);

        /// <summary>
        /// Возвращает список возможных типов релизов в каталоге.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="TypeShort"/>, содержащий типы релизов.</returns>
        public Task<List<TypeShort>?> GetTypesAsync(CancellationToken token = default) => GetDirectoryListAsync<TypeShort>("types", token);

        /// <summary>
        /// Возвращает список годов в каталоге.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список значений <see cref="int"/>, содержащий годы выхода релизов.</returns>
        public Task<List<int>?> GetYearsAsync(CancellationToken token = default) => GetDirectoryListAsync<int>("years", token);
        #endregion

        #region Anime.Franchises

        /// <summary>
        /// Возвращает список франшиз.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="Franchise"/>, содержащих данные по франшизам.</returns>
        public Task<List<Franchise>?> GetFranchisesAsync(CancellationToken token = default) =>
            SafeExecuteAsync(() => GetFromAPIAsync("anime/franchises", new List<Franchise>(), token));

        /// <summary>
        /// Возвращает данные франшизы.
        /// </summary>
        /// <param name="franchiseId">ID франшизы</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="AnimeFranchiseResponse"/>, содержащий данные по франшизе.</returns>
        public Task<AnimeFranchiseResponse?> GetFranchiseByIdAsync(string franchiseId, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/franchises/{franchiseId}", new AnimeFranchiseResponse(), token));

        /// <summary>
        /// Возвращает список случайных франшиз.
        /// </summary>
        /// <param name="limit">Количество случайных франшиз в выдаче. По умолчанию 5.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="Franchise"/>, полученных случайным образом.</returns>
        public Task<List<Franchise>?> GetRandomFranchisesAsync(int limit = 5, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/franchises/random?limit={limit}", new List<Franchise>(), token));

        /// <summary>
        /// Возвращает список франшиз, в которых участвует релиз.
        /// </summary>
        /// <param name="releaseId">ID релиза</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Список объектов <see cref="AnimeFranchiseResponse"/>, в которых участвует релиз.</returns>
        public Task<List<AnimeFranchiseResponse>?> GetFranchisesForReleaseAsync(string releaseId, CancellationToken token = default) =>
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/franchises/release/{releaseId}", new List<AnimeFranchiseResponse>(), token));

        #endregion

        #region Anime.Genres

        /// <summary>
        /// Возвращает список всех жанров.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="Genre"/>, в которых содержатся детальные данные по всем жанрам.</returns>
        public Task<List<Genre>?> GetDetailGenresAsync(CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync("anime/genres", new List<Genre>(), token));

        /// <summary>
        /// Возвращает данные по жанру.
        /// </summary>
        /// <param name="genreId">ID Жанра</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="Genre"/>, содержащий информацию по жанру.</returns>
        public Task<Genre?> GetGenreById(int genreId, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/genres/{genreId}", new Genre(), token));

        /// <summary>
        /// Возвращает список случайных жанров.
        /// </summary>
        /// <param name="limit">Количество жанров в выдаче. По умолчанию 5.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Случайная коллекция объектов <see cref="Genre"/>.</returns>
        public Task<List<Genre>?> GetRandomGenresAsync(int limit = 5, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/genres/random?limit={limit}", new List<Genre>(), token));

        /// <summary>
        /// Возвращает список всех релизов жанра.
        /// </summary>
        /// <param name="genreId">ID Жанра</param>
        /// <param name="page">Номер страницы. По умолчанию 1.</param>
        /// <param name="limit">Ограничение на количество элементов. По умолчанию 10.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="PaginatedResponse{T}"/>, содержащий коллекцию релизов жанра.</returns>
        public Task<PaginatedResponse<Release>?> GetReleasesByGenreAsync(int genreId, int page = 1, int limit = 10, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/genres/{genreId}/releases?page={page}&limit={limit}", new PaginatedResponse<Release>(), token));

        #endregion

        #region Anime.Releases

        /// <summary>
        /// Возвращает данные по последним релизам.
        /// </summary>
        /// <param name="limit">Количество последних релизов в выдаче. По умолчанию 10.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="LatestReleaseResponse"/>, содержащих последние релизы.</returns>
        public Task<List<LatestReleaseResponse>?> GetLatestReleasesAsync(int limit = 10, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/latest?limit={limit}", new List<LatestReleaseResponse>(), token));

        /// <summary>
        /// Возвращает данные по случайным релизам.
        /// </summary>
        /// <param name="limit">Количество случайных релизов. По умолчанию 5.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция случайных релизов <see cref="Release"/></returns>
        public Task<List<Release>?> GetRandomReleasesAsync(int limit = 5, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/random?limit={limit}", new List<Release>(), token));

        /// <summary>
        /// Возвращает данные по рекомендованным релизам.
        /// </summary>
        /// <param name="limit">Количество рекомендованных релизов. По умолчанию 5.</param>
        /// <param name="forRecReleaseId">Идентификатор релиза, для которого рекомендуем.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция рекомендованных релизов <see cref="Release"/></returns>
        public Task<List<Release>?> GetRecommendedReleasesAsync(int limit = 5, int? forRecReleaseId = null, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync(
                forRecReleaseId is null 
                    ? $"anime/releases/recommended?limit={limit}" 
                    : $"anime/releases/recommended?limit={limit}&release_id={forRecReleaseId}", 
                new List<Release>(), token));

        /// <summary>
        /// Возвращает данные по списку релизов.
        /// </summary>
        /// <param name="queryParametrs">Модель параметров. Обязателен ID-лист или Aliases.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="ReleasesListResponse"/>, которые соответствуют переданному списку Id.</returns>
        public Task<PaginatedResponse<ReleasesListResponse>?> GetReleasesByListIdsAsync(ReleasesListQueryDto queryParameters, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/list?{QueryBuilder.Build(queryParameters)}", new PaginatedResponse<ReleasesListResponse>() { Data = new List<ReleasesListResponse>() }, token));

        /// <summary>
        /// Возвращает данные по релизу.
        /// </summary>
        /// <param name="idOrAlias">ID или Alias релиза</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="ReleasesListResponse"/>, в котором содержатся данные по релизу.</returns>
        public Task<ReleasesListResponse?> GetReleaseByIdAsync(string idOrAlias, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/{idOrAlias}", new ReleasesListResponse(), token));

        /// <inheritdoc cref="GetReleaseByIdAsync(string, CancellationToken)"/>
        public Task<ReleasesListResponse?> GetReleaseByIdAsync(int idOrAlias, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/{idOrAlias}", new ReleasesListResponse(), token));

        /// <summary>
        /// Возвращает данные по участникам релиза.
        /// </summary>
        /// <param name="idOrAlias">ID или Alias релиза.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция участников релиза <see cref="Member"/>.</returns>
        public Task<List<Member>?> GetReleaseStaffAsync(string idOrAlias, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/{idOrAlias}/members", new List<Member>(), token));

        /// <inheritdoc cref="GetReleaseStaffAsync(string, CancellationToken)"/>
        public Task<List<Member>?> GetReleaseStaffAsync(int idOrAlias, CancellationToken token = default) =>
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/{idOrAlias}/members", new List<Member>(), token));

        /// <summary>
        /// Возвращает данные по всем существующим таймкодам просмотра эпизодов релиза. Имеет 1-2 минутный кэш.
        /// </summary>
        /// <param name="idOrAlias">ID или Alias релиза.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="TimecodesResponse"/>,  в которых содержится информация по существующим таймкодом просмотра релиза. </returns>
        public Task<List<TimecodesResponse>?> GetTimecodesByEpisodesAsync(string idOrAlias, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/{idOrAlias}/episodes/timecodes", new List<TimecodesResponse>(), token));

        /// <inheritdoc cref="GetTimecodesByEpisodesAsync(string, CancellationToken)"/>>
        public Task<List<TimecodesResponse>?> GetTimecodesByEpisodesAsync(int idOrAlias, CancellationToken token = default) =>
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/{idOrAlias}/episodes/timecodes", new List<TimecodesResponse>(), token));

        #endregion

        #region Anime.Releases.Episodes
        
        /// <summary>
        /// Возвращает данные по эпизоду.
        /// </summary>
        /// <param name="releaseEpisodeId">Идентификатор эпизода.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="EpisodeResponse"/>, содержащий информацию об эпизоде.</returns>
        public Task<EpisodeResponse?> GetEpisodeAsync(string releaseEpisodeId, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/episodes/{releaseEpisodeId}", new EpisodeResponse(), token));

        /// <summary>
        /// Возвращает данные по просмотру указанного эпизода авторизованным пользователем. Имеет 1-2 минутный кэш.
        /// </summary>
        /// <param name="releaseEpisodeId">Идентификатор эпизода.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="TimecodesResponse"/>, содержащий информацию по просмотру указанного эпизода авторизованным пользователям.</returns>
        public Task<TimecodesResponse?> GetEpisodeWatchTimecodesAsync(string releaseEpisodeId, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/releases/episodes/{releaseEpisodeId}/timecode", new TimecodesResponse(), token));

        #endregion

        #region Anime.Releases.ResultSchedule

        /// <summary>
        /// Возвращает список релизов в расписании на текущую дату.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="PaginatedScheduleResponse{T}"/>, содержащий мета-данные и информацию о расписании релизов на текущую дату.</returns>
        public Task<PaginatedScheduleResponse<ScheduleReleaseResponse>?> GetScheduleReleasesNowAsync(CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync("anime/schedule/now", new PaginatedScheduleResponse<ScheduleReleaseResponse>() { 
                Today = new List<ScheduleReleaseResponse>(), 
                Tomorrow = new List<ScheduleReleaseResponse>(), 
                Yesterday = new List<ScheduleReleaseResponse>() 
            }, token));

        /// <summary>
        /// Возвращает список релизов в расписании на текущую неделю.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="PaginatedScheduleResponse{T}"/>, содержащий мета-данные и информацию о расписании релизов на текущую неделю.</returns>
        public Task<PaginatedScheduleResponse<ScheduleReleaseResponse>?> GetScheduleReleasesWeekAsync(CancellationToken token = default) =>
            SafeExecuteAsync(() => GetFromAPIAsync("anime/schedule/week", new PaginatedScheduleResponse<ScheduleReleaseResponse>()
            {
                Today = new List<ScheduleReleaseResponse>(),
                Tomorrow = new List<ScheduleReleaseResponse>(),
                Yesterday = new List<ScheduleReleaseResponse>()
            }, token));

        #endregion

        #region Anime.Torrents

        /// <summary>
        /// Возвращает данные по последним торрентам.
        /// </summary>
        /// <param name="page">Номер страницы. По умолчанию 1.</param>
        /// <param name="limit">Ограничение на количество элементов. По умолчанию 10.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="PaginatedResponse{T}"/>, содержащий мета-данные и информацию о торрентах.</returns>
        public Task<PaginatedResponse<TorrentResponse>?> GetTorrents(int page = 1, int limit = 10, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/torrents?page={page}&limit={limit}", new PaginatedResponse<TorrentResponse>() { Data = new List<TorrentResponse>()}, token));

        /// <summary>
        /// Возвращает данные по торренту.
        /// </summary>
        /// <param name="hashOrId">Hash или ID торрента.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="TorrentResponse"/>, содержащий информацию о торренте.</returns>
        public Task<TorrentResponse?> GetTorrentByIdAsync(string hashOrId, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/torrents/{hashOrId}", new TorrentResponse(), token));

        /// <summary>
        /// Возвращает торрент-файл.
        /// </summary>
        /// <param name="hashOrId">Hash или ID торрента.</param>
        /// <param name="pk">Passkey пользователя.</param>
        /// <param name="token"></param>
        /// <returns>Массив байтов, представляющий содержимое торрент-файла.</returns>
        public Task<byte[]?> GetTorrentBytesAsync(string hashOrId, string pk = "", CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/torrents/{hashOrId}/file?pk={pk}", Array.Empty<byte>(), token));

        /// <summary>
        /// Возвращает данные по торрентам релиза.
        /// </summary>
        /// <param name="releaseId">ID Релиза</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="TorrentResponse"/>, содержащая информацию по торрентам релиза.</returns>
        public Task<List<TorrentResponse>?> GetTorrentByRealeseAsync(int releaseId, CancellationToken token) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"anime/torrents/release/{releaseId}", new List<TorrentResponse>(), token));

        /// <summary>
        /// Возвращает данные по последним торрентам в виде XML документа.
        /// </summary>
        /// <param name="limit">Количество торрентов в выдаче. По умолчанию 10.</param>
        /// <param name="pk">Пользовательский Passkey. Персонализирует ссылки на торренты для учета статистики.</param>
        /// <param name="token">ТОкен отмены</param>
        /// <returns>XML-документ, содержащий информацию по последним торрентам.</returns>
        public async Task<XmlDocument?> GetTorrentsXMLAsync(int limit = 10, string pk = "", CancellationToken token = default)
        {
            return await SafeExecuteAsync(async () =>
            {
                using HttpResponseMessage response = await _httpClient.GetAsync($"anime/torrents/rss?limit={limit}&pk={pk}", token).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode) { return new XmlDocument(); }

                XmlDocument doc = new();
                doc.Load(await response.Content.ReadAsStreamAsync(token));

                return doc;
            });
        }

        /// <summary>
        /// Возвращает данные по торрентам релиза в виде RSS (Really Simple Syndication) ленты.
        /// </summary>
        /// <param name="releaseId">ID Релиза.</param>
        /// <param name="pk">Пользовательский Passkey. Персонализирует ссылки на торренты для учета статистики.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>XML-документ в виде RSS ленты.</returns>
        public async Task<XmlDocument> GetTorrentsXMLByReleaseAsync(int releaseId, string pk = "", CancellationToken token = default)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"anime/torrents/rss/release/{releaseId}?pk={pk}", token).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode) { return new XmlDocument(); }

            XmlDocument doc = new();
            doc.Load(await response.Content.ReadAsStreamAsync(token));

            return doc;
        }
        #endregion

        #region App

        /// <summary>
        /// Возвращает данные по релизам, которые удовлетворяют поисковому запросу.
        /// </summary>
        /// <param name="query">Поисковая строка.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="Release"/>, удовлетворяющих поисковому запросу.</returns>
        public Task<List<Release>?> SearchReleasesAsync(string query, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"app/search/releases?query={query}", new List<Release>(), token));

        /// <summary>
        /// Возвращает информацию о статусе API.
        /// </summary>
        /// <param name="token">Токен отмены.</param>
        /// <returns>Объект <see cref="Status"/>, содержащий информацию о статусе API.</returns>
        public Task<Status?> GetApiStatusAsync(CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync("app/status", new Status(), token));
        #endregion

        #region Media

        /// <summary>
        /// Возвращает список промо-материалов или рекламные кампании в случайном порядке.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="{PaginatedResponse{PromotionResponse}"/>, содержащий мета-данные запроса и коллекцию объектов <see cref="PromotionResponse"/> с информацией о промо-материалах и рекламных кампаниях.</returns>
        public Task<PaginatedResponse<PromotionResponse>?> GetPromotionsAsync(CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync("media/promotions", new PaginatedResponse<PromotionResponse>() { Data = new List<PromotionResponse>() }, token));

        /// <summary>
        /// Возвращает список последних видео-роликов.
        /// </summary>
        /// <param name="limit">Количество роликов в выдаче.</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Объект <see cref="{PaginatedResponse{VideoResponse}"/>, содержащий мета-данные запроса и коллекцию объектов <see cref="VideoResponse"/> с информацией о последних видеороликах.</returns>
        public Task<PaginatedResponse<VideoResponse>?> GetVideosAsync(int limit = 10, CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync($"media/videos?limit={limit}", new PaginatedResponse<VideoResponse>() { Data = new List<VideoResponse>() }, token));
        #endregion

        #region Teams

        /// <summary>
        /// Возвращает список всех команд.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="Team"/>, содержащая информацию о всех командах AniLibria.</returns>
        public Task<List<Team>?> GetAnilibertyTeamsAsync(CancellationToken token = default) => 
            SafeExecuteAsync(() => GetFromAPIAsync("teams", new List<Team>(), token));

        /// <summary>
        /// Возвращает список всех ролей в командах.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="TeamRole"/>, содержащая информацию о всех ролях внутри командах.</returns>
        public Task<List<TeamRole>?> GetAnilibertyTeamRolesAsync(CancellationToken token) => 
            SafeExecuteAsync(() => GetFromAPIAsync("teams/roles", new List<TeamRole>(), token));

        /// <summary>
        /// Возвращает список всех анилибрийцов с указанием команды и своих ролей.
        /// </summary>
        /// <param name="token">Токен отмены</param>
        /// <returns>Коллекция объектов <see cref="AniUserResponse"/>, содержащая информацию о наших слонах.</returns>
        public Task<List<AniUserResponse>?> GetAniMembersAsync(CancellationToken token) => 
            SafeExecuteAsync(() => GetFromAPIAsync("teams/users", new List<AniUserResponse>(), token));
        
        #endregion
    }
}