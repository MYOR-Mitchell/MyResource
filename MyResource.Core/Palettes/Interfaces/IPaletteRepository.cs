using MyResource.Core.Palettes.Models;

namespace MyResource.Core.Palettes.Interfaces
{
    public interface IPaletteRepository
    {
        Task<Palette?> GetRandomPaletteAsync();
        Task AddPaletteAsync(Palette palette);
        Task<bool> DeletePaletteAsync(int id);
    }
}
