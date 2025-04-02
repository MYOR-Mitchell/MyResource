namespace MyResource.Core.WordSearch.Logic.Locations
{
    public class AssignStartPoint
    {
        private readonly Random _random;
        public AssignStartPoint(Random random)
        {
            _random = random;
        }

        public (int, int) AssignStart(int gridSize)
        {
            int yLocation = _random.Next(0, gridSize);
            int xLocation = _random.Next(0, gridSize);
            return (yLocation, xLocation);
        }
    }
}
