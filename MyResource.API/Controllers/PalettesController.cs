using Microsoft.AspNetCore.Mvc;
using MyResource.Core.Features.Palettes.Models;

namespace MyResource.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalettesController : ControllerBase
    {
        private readonly MyResourceContext _context;

        public PalettesController(MyResourceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostPalette(Palette palette)
        {
            _context.Palettes.Add(palette);
            await _context.SaveChangesAsync();
            return Ok(palette);
        }
    }
}
