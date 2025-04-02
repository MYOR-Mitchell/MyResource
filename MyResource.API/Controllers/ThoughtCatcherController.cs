using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyResource.Data;
using MyResource.Shared.DTOs.ThoughtCatcher;
using MyResource.Core.ThoughtCatcher.Models;

namespace MyResource.API.Controllers
{
    [ApiController]
    [Route("api/thoughts")]
    public class ThoughtCatcherController : ControllerBase
    {
        private readonly MyResourceContext _context;

        public ThoughtCatcherController(MyResourceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddThought([FromBody] ThoughtDto dto)
        {
            var thought = new Thought {
                Title = dto.Title,
                Body = dto.Body,
                UserId = dto.UserId
            };

            _context.Thoughts.Add(thought);
            await _context.SaveChangesAsync();

            var response = new ThoughtResponseDto {
                ThoughtId = thought.ThoughtId,
                Title = thought.Title,
                Body = thought.Body
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditThought(int id, [FromBody] ThoughtDto dto)
        {
            var thought = await _context.Thoughts.FindAsync(id);
            if(thought == null)
            {
                return NotFound();
            }

            thought.Title = dto.Title;
            thought.Body = dto.Body;
            thought.UserId = dto.UserId;

            await _context.SaveChangesAsync();
            return Ok(thought);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThoughtResponseDto>>> GetThoughts()
        {
            var thoughts = await _context.Thoughts
                .Select(t => new ThoughtResponseDto {
                    ThoughtId = t.ThoughtId,
                    Title = t.Title,
                    Body = t.Body
                })
                .ToListAsync();

            return Ok(thoughts);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThought(int id)
        {
            var thought = await _context.Thoughts.FindAsync(id);
            if(thought == null)
            {
                return NotFound();
            }

            _context.Thoughts.Remove(thought);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

