using System.Net.Http.Json;
using MyResource.Shared.DTOs.ThoughtCatcher;

namespace MyResource.Services.ThoughtCatcher
{
    public class ThoughtService
    {
        private readonly HttpClient _http;

        public ThoughtService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ThoughtResponseDto>> GetThoughts()
            => await _http.GetFromJsonAsync<List<ThoughtResponseDto>>("api/thoughts");

        public async Task<ThoughtResponseDto?> AddThought(ThoughtDto dto)
        {
            var res = await _http.PostAsJsonAsync("api/thoughts", dto);
            return await res.Content.ReadFromJsonAsync<ThoughtResponseDto>();
        }

        public async Task<ThoughtResponseDto?> UpdateThought(int id, ThoughtDto dto)
        {
            var res = await _http.PutAsJsonAsync($"api/thoughts/{id}", dto);
            return await res.Content.ReadFromJsonAsync<ThoughtResponseDto>();
        }

        public async Task<bool> DeleteThought(int id)
        {
            var res = await _http.DeleteAsync($"api/thoughts/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
