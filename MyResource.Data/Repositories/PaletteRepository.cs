using Microsoft.EntityFrameworkCore;
using MyResource.Core.Palettes.Interfaces;
using MyResource.Core.Palettes.Models;

namespace MyResource.Data.Repositories
{
    public class PaletteRepository : IPaletteRepository
    {
        private readonly MyResourceContext _context;

        public PaletteRepository(MyResourceContext context)
        {
            _context = context;
        }

        public async Task<Palette?> GetRandomPaletteAsync()
        {
            var total = await _context.Palettes.CountAsync();
            if(total == 0)
                return null;

            var randomIndex = new Random().Next(0, total);
            return await _context.Palettes.Skip(randomIndex).Take(1).FirstOrDefaultAsync();
        }

        public async Task AddPaletteAsync(Palette palette)
        {
            _context.Palettes.Add(palette);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePaletteAsync(int id)
        {
            var palette = await _context.Palettes.FindAsync(id);
            if(palette == null)
                return false;

            _context.Palettes.Remove(palette);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


