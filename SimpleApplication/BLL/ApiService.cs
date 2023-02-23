using SimpleApplication.Interfaces;
using SimpleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleApplication.BLL
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        //public async Task<Result> GetEntries(string category)
        //{
        //    var response = await _httpClient.GetAsync($"https://api.publicapis.org/entries?Category={category}");
        //    var json = await response.Content.ReadAsStringAsync();
        //    return JsonSerializer.Deserialize<Result>(json);
        //}
        public async Task<Result> GetAnimals()
        {
            var response = await _httpClient.GetAsync("https://api.publicapis.org/entries?Category=Animals");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Result>(json);
        }

        public async Task<Result> GetWeather()
        {
            var response = await _httpClient.GetAsync("https://api.publicapis.org/entries?Category=Weather");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Result>(json);
        }
        public async Task<Result> GetVideo()
        {
            var response = await _httpClient.GetAsync("https://api.publicapis.org/entries?Category=Video");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Result>(json);
        }
        public async Task<Result> GetHealth()
        {
            var response = await _httpClient.GetAsync("https://api.publicapis.org/entries?Category=Health");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Result>(json);
        }
    }
}
