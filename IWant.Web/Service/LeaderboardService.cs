using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace IWant.Web.Service
{
    public class LeaderboardService : ILeaderboardService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly string _gameAPIKey = "dev_198b80b1aa6a405d89f3428dd6276e10";
        private readonly string _serverAPIKey = "dev_4521d456137c4b74a5a07a8e40147001";
        private readonly string _baseURL = "https://75py6bqd.api.lootlocker.io/game/leaderboards/";

        private readonly Dictionary<string, int> _leaderboardIDs = new()
        {
            { "EmotionSelection", 30287 },
            { "DotConnection", 30388 },
            { "FruitDrop", 30288 }
        };

        public LeaderboardService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        private async Task<string> GetSessionTokenAsync()
        {
            if (_cache.TryGetValue("SessionToken", out string cachedToken))
                return cachedToken;

            var request = new HttpRequestMessage(HttpMethod.Post, "https://75py6bqd.api.lootlocker.io/game/v2/session/guest")
            {
                Headers = { { "x-api-key", _gameAPIKey } },
                Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    game_key = _gameAPIKey,
                    player_identifier = Guid.NewGuid().ToString(),
                    game_version = "1.0"
                }), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Không thể lấy x-session-token từ LootLocker.");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var sessionToken = JsonConvert.DeserializeObject<dynamic>(jsonResponse)?.session_token;

            _cache.Set("SessionToken", (string)sessionToken, TimeSpan.FromMinutes(60));
            return sessionToken;
        }

        private async Task<List<LeaderboardEntry>> FetchLeaderboardAsync(int leaderboardID, string sessionToken)
        {
            var url = $"{_baseURL}{leaderboardID}/list";
            var request = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
                {
                    { "x-api-key", _serverAPIKey },
                    { "x-session-token", sessionToken }
                }
            };

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return new List<LeaderboardEntry>();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var leaderboardData = JsonConvert.DeserializeObject<LeaderboardData>(jsonResponse)?.items ?? new List<LeaderboardEntry>();

            return leaderboardData
                .Where(entry => !string.IsNullOrEmpty(entry.metadata))
                .GroupBy(entry => entry.GetUserId())
                .Select(group => group.OrderByDescending(entry => entry.score).First())
                .ToList();
        }

        public async Task<LeaderboardResponse> GetLeaderboardsAsync()
        {
            string sessionToken = await GetSessionTokenAsync();

            var fetchTasks = _leaderboardIDs.ToDictionary(
                entry => entry.Key,
                entry => FetchLeaderboardAsync(entry.Value, sessionToken)
            );

            await Task.WhenAll(fetchTasks.Values);

            return new LeaderboardResponse
            {
                EmotionSelections = fetchTasks["EmotionSelection"].Result,
                DotConnections = fetchTasks["DotConnection"].Result,
                FruitDrops = fetchTasks["FruitDrop"].Result
            };
        }
    }
}

public class LeaderboardResponse
{
    public List<LeaderboardEntry> EmotionSelections { get; set; } = new List<LeaderboardEntry>();
    public List<LeaderboardEntry> DotConnections { get; set; } = new List<LeaderboardEntry>();
    public List<LeaderboardEntry> FruitDrops { get; set; } = new List<LeaderboardEntry>();
}

public class LeaderboardData
{
    public List<LeaderboardEntry> items { get; set; } = new List<LeaderboardEntry>();
}

public class LeaderboardEntry
{
    public int score { get; set; }
    public string metadata { get; set; }

    public string GetUserId()
    {
        if (string.IsNullOrEmpty(metadata)) return "N/A";
        try
        {
            return JsonConvert.DeserializeObject<Metadata>(metadata)?.UserId ?? "N/A";
        }
        catch
        {
            return "N/A";
        }
    }
}

public class Metadata
{
    public string UserId { get; set; }
}

