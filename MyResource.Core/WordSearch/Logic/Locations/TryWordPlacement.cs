namespace MyResource.Core.WordSearch.Logic.Locations
{
    public class TryWordPlacement
    {
        public bool TryPlacement(List<char[]> grid, List<(int, int)> wordCoords, string word)
        {
            for(int i = 0; i < wordCoords.Count; i++)
            {
                (int y, int x) = wordCoords[i];

                if(grid[y][x] != ' ' && grid[y][x] != word[i])
                {
                    return false;
                }
            }

            for(int i = 0; i < wordCoords.Count; i++)
            {
                (int y, int x) = wordCoords[i];

                grid[y][x] = word[i];
            }

            return true;
        }
    }
}
