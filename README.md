# Aniliberty.NET
AniLiberty SDK  — это .NET библиотека для работы с AniLiberty API.

## Установка пакета NuGet
Ссылка на [NuGet](https://www.nuget.org/packages/AniLiberty.NET)

Команда терминала: 
`dotnet add package AniLiberty.NET --version 1.0.1`

## Инициализация клиента

`AnilibertyClient` является точкой входа в Aniliberty SDK.
Он инкапсулирует работу с API и предоставляет удобные методы-обертки для получения данных о релизах, жанрах, франшизах и других сущностях.

Вместо ручного построения HTTP-запросов и десериализации JSON, достаточно вызвать соответствующий метод клиента. `AnilibertyClient` можно создать двумя способами:

### 1. Через готовый `HttpClient`

Рекомендуется использоваться в **ASP.NET Core** или других приложениях, где уже есть DI-контейнер и `IHttpClientFactory`.

Так удастся избежать проблем с количеством сокетов и получить полный контроль над конфигурацией `HttpClient`.

```csharp
using AniLiberty.NET.Client;

HttpClient httpClient = new HttpClient();
AnilibertyClient AniClient = new AnilibertyClient(httpClient);

var result = await AniClient.GetAgeRatingsAsync();
``` 

Так же конструктор принимает `string? baseAdress`, в котором можно указать базовый адрес сервера, откуда будут получаться данные. По умолчанию `https://anilibria.top/api/v1/`.

```csharp 
AnilibertyClient AniClient = new AnilibertyClient(httpClient, "https://aniliberty.top/api/v1/");
```

### 2. Автоматическое создание `HttpClient`

Удобно для быстрых тестов, прототипов и небольших приложений.

Клиент сам создает `HttpClient` с дефолтным базовым адресом `https://anilibria.top/api/v1/`.

```csharp 
using AniLiberty.NET.Client;

AnilibertyClient client = new AnilibertyClient();

var result = await AniClient.GetAgeRatingsAsync();
```
