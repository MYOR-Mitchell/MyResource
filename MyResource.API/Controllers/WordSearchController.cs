using Microsoft.AspNetCore.Mvc;
using MyResource.Core.WordSearch.Interfaces;
using MyResource.Core.WordSearch.Models;
using MyResource.Shared.DTOs.WordSearch;

namespace MyResource.API.Controllers
{
    [ApiController]
    [Route("api/wordsearch")]
    public class WordSearchController : ControllerBase
    {
        private readonly ICreatePuzzle _createPuzzle;

        public WordSearchController(ICreatePuzzle createPuzzle)
        {
            _createPuzzle = createPuzzle;
        }

        [HttpPost]
        public IActionResult GenerateWordSearch([FromBody] WordSearchDto dto)
        {
            if(dto?.Words == null || !dto.Words.Any() || dto.GridSize < 3)
            {
                return BadRequest(new { message = "Invalid input. Please check your words and grid size." });
            }

            foreach(var word in dto.Words)
            {
                if(word.Length > dto.GridSize)
                {
                    return BadRequest(new { message = "Words cannot be larger than the grid size." });
                }
            }

            int gridCells = dto.GridSize * dto.GridSize;
            int wordCharacters = dto.Words.Sum(w => w.Length);

            if(wordCharacters > gridCells / 2)
            {
                return BadRequest(new { message = "Total word character count exceeded." });
            }

            var model = new WordSearchModel {
                Words = dto.Words,
                GridSize = dto.GridSize
            };

            var (success, grid) = _createPuzzle.Create(model);

            if(!success || grid is null)
            {
                return BadRequest(new { message = "Unable to create puzzle, please try again." });
            }

            var response = new WordSearchResponseDto {
                Grid = grid
            };

            return Ok(response);
        }
    }
}
