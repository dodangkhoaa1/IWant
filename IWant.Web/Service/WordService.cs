using IWant.BusinessObject.Enitities;
using IWant.Web.Models;
using System.Text;
using System.Text.Json;

namespace IWant.Web.Service
{
    public class WordService : IWordService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:5000/api/Words";
        private const string ApiCategoryUrl = "http://localhost:5000/api/WordCategories";

        public WordService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Word> CreateWordAsync(Word word)
        {
            using var form = new MultipartFormDataContent();
            form.Add(new StringContent(word.VietnameseText), "VietnameseText");
            if (!string.IsNullOrEmpty(word.EnglishText))
                form.Add(new StringContent(word.EnglishText), "EnglishText");
            form.Add(new StringContent(word.WordCategoryId.ToString()), "WordCategoryId");

            // Kiểm tra nếu có file ảnh
            if (word.ImageFile != null)
            {
                var stream = word.ImageFile.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(word.ImageFile.ContentType);
                form.Add(fileContent, "ImageFile", word.ImageFile.FileName);
            }

            var response = await _httpClient.PostAsync(ApiBaseUrl, form);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Word>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }





        public async Task<Word> DeleteWordAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Word>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Word> GetWordByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Word>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<Word>> GetWordsAsync()
        {
            var response = await _httpClient.GetAsync(ApiBaseUrl);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Word>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Word> UpdateWordAsync(Word word)
        {
            var json = JsonSerializer.Serialize(word);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{ApiBaseUrl}/{word.Id}", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Word>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<WordCategory>> GetCategorysAsync()
        {
            var response = await _httpClient.GetAsync(ApiCategoryUrl);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<WordCategory>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<WordCategory> GetWordCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{ApiCategoryUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WordCategory>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
