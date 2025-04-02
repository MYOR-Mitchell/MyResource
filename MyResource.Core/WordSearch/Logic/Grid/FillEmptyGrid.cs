namespace MyResource.Core.WordSearch.Logic.Grid
{
    public class FillEmptyGrid
    {
        private readonly char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly Random random;

        public FillEmptyGrid()
        {
            random = new Random();
        }

        public void FillGrid(List<char[]> grid)
        {
            for(int y = 0; y < grid.Count; y++)
            {
                for(int x = 0; x < grid[y].Length; x++)
                {
                    if(grid[y][x] == ' ') 
                    {
                        grid[y][x] = GenerateLetter();
                    }
                }
            }
        }

        private char GenerateLetter()
        {
            var letter = random.Next(0, letters.Length);
            return letters[letter];
        }
    }
}