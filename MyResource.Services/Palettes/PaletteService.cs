using MyResource.Shared.DTOs.Palettes;
using System.Net.Http.Json;

namespace MyResource.Services.Palettes
{
    public class PaletteService
    {
        private readonly HttpClient _http;

        public PaletteService(HttpClient http)
        {
            _http = http;
        }
        public async Task<bool> SavePalette(PaletteDto dto)
        {
            var res = await _http.PostAsJsonAsync("api/palettes", dto);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePalette(int id)
        {
            var res = await _http.DeleteAsync($"api/palettes/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<PaletteDto?> GetRandomPalette()
        {
            return await _http.GetFromJsonAsync<PaletteDto>("api/palettes/random");
        }
    }
}
