using Microsoft.AspNetCore.Mvc;
using MyResource.Core.Palettes.Models;
using MyResource.Core.Palettes.Interfaces;

namespace MyResource.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalettesController : ControllerBase
    {
        private readonly IPaletteRepository _paletteRepository;

        public PalettesController(IPaletteRepository paletteRepository)
        {
            _paletteRepository = paletteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SavePalette([FromBody] Palette dto)
        {
            await _paletteRepository.AddPaletteAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePalette(int id)
        {
            var success = await _paletteRepository.DeletePaletteAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet("random")]
        public async Task<ActionResult<Palette>> GetRandom()
        {
            var palette = await _paletteRepository.GetRandomPaletteAsync();
            return palette is null ? NotFound() : Ok(palette);
        }
    }
}

