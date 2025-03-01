using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IWant.Web.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _gameAPIKey = "dev_4521d456137c4b74a5a07a8e40147001";
        private readonly string _sessionTokenKey = "8ce989a2126973eef1aa45480ad5998456b37420";
        private readonly int _fruitDrop_LeaderboardID = 30288;
        private readonly int _emotionSelection_LeaderboardID = 30287;
        private readonly string _baseURL = "https://75py6bqd.api.lootlocker.io/game/leaderboards/";

        public LeaderboardController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Route("Leaderboard")]
        [Route("Leaderboard/Index")]
        public async Task<IActionResult> Index()
        {
            var url = $"{_baseURL}{_emotionSelection_LeaderboardID}/list";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-api-key", _gameAPIKey);
            request.Headers.Add("x-session-token", _sessionTokenKey);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Không thể lấy dữ liệu từ LootLocker.";
                return View();
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var leaderboardData = JsonConvert.DeserializeObject<LeaderboardResponse>(jsonResponse);

            return View(leaderboardData);
        }
    }

    // Định nghĩa class để parse JSON
    public class LeaderboardResponse
    {
        public LeaderboardEntry[]? items { get; set; }
    }


    public class LeaderboardEntry
    {
        public int rank { get; set; }
        public int score { get; set; }
        public Player player { get; set; }
        public string metadata { get; set; }

        public string GetUserId()
        {
            if (string.IsNullOrEmpty(metadata)) return "N/A";
            try
            {
                var metadataObj = JObject.Parse(metadata);
                return metadataObj["userId"]?.ToString() ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }
    }

    public class Player
    {
        public string name { get; set; }
    }
}
