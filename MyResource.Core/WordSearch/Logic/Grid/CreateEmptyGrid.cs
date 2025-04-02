namespace MyResource.Core.WordSearch.Logic.Grid
{
    public class CreateEmptyGrid
    {
        public List<char[]> CreateGrid(int gridSize)
        {
            List<char[]> Rows = new List<char[]>();

            for(int i = 0; i < gridSize; i++)
            {
                char[] row = new char[gridSize];

                for(int j = 0; j < gridSize; j++)
                {
                    row[j] = ' '; 
                }
                Rows.Add(row);
            }
            return Rows;
        }

    }
}
