

namespace MyResource.Shared.DTOs.WordSearch
{
    public class WordSearchDto
    {
        public List<string> Words { get; set; } = new();
        public int GridSize { get; set; }
    }
}
