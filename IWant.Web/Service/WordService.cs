﻿using IWant.BusinessObject.Enitities;
using IWant.Web.Models;
using IWant.Web.Models.DTO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace IWant.Web.Service
{
    public class WordService : IWordService
    {
        private readonly HttpClient _httpClient;

        //private const string HOST = "http://localhost:5000"; //local
        private const string HOST = "https://iwantapiservice.azurewebsites.net"; //cloud

        private const string ApiBaseUrl = $"{HOST}/api/Words";
        private const string ApiCategoryUrl = $"{HOST}/api/WordCategories";

        public WordService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Allow to create a new word
        public async Task<Word> CreateWordAsync(Word word)
        {
            WordDTO wordDTO = new()
            {
                VietnameseText = word.VietnameseText,
                EnglishText = word.EnglishText,
                CreatedAt = word.CreatedAt,
                UpdatedAt = word.UpdatedAt,
                ImagePath = word.ImagePath,
                Status = word.Status,
                WordCategoryId = word.WordCategoryId,
                WordCategory = word.WordCategory,
                UserId = "0bcbb4f7-72f9-435f-9cb3-1621b4503974"
            };
            // Kiểm tra nếu có file ảnh
            if (word.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await word.ImageFile.CopyToAsync(memoryStream);
                wordDTO.Image = memoryStream.ToArray();
            }

            var json = JsonSerializer.Serialize(wordDTO);
            var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));

            var response = await _httpClient.PostAsync(ApiBaseUrl, content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Word>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Allow to delete a word by id
        public async Task<bool> DeleteWordAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            return response.StatusCode == HttpStatusCode.OK;
        }

        // Allow to get a word by id
        public async Task<Word> GetWordByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Word>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Allow to get all words
        public async Task<List<Word>> GetWordsAsync()
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/user/0bcbb4f7-72f9-435f-9cb3-1621b4503974");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Word>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Allow to update a word
        public async Task<Word> UpdateWordAsync(Word word)
        {
            WordDTO wordDTO = new()
            {
                Id = word.Id,
                UserId = word.UserId,
                VietnameseText = word.VietnameseText,
                EnglishText = word.EnglishText,
                CreatedAt = word.CreatedAt,
                UpdatedAt = word.UpdatedAt,
                ImagePath = word.ImagePath,
                Status = word.Status,
                WordCategoryId = word.WordCategoryId,
                WordCategory = word.WordCategory,
            };
            // Kiểm tra nếu có file ảnh
            if (word.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await word.ImageFile.CopyToAsync(memoryStream);
                wordDTO.Image = memoryStream.ToArray();
            }

            var json = JsonSerializer.Serialize(wordDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{ApiBaseUrl}/{word.Id}", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Word>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Allow to get all word categories
        public async Task<List<WordCategory>> GetCategorysAsync()
        {
            var response = await _httpClient.GetAsync(ApiCategoryUrl);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<WordCategory>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Allow to get a word category by id
        public async Task<WordCategory> GetWordCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{ApiCategoryUrl}/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WordCategory>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
