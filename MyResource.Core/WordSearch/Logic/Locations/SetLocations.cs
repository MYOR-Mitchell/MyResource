namespace MyResource.Core.WordSearch.Logic.Locations
{
    public class SetLocations
    {
        private readonly Random _random;
        private readonly AssignStartPoint _assignStartPoint;
        private readonly CheckBoundary _checkBoundary;
        private readonly AssignWordCoordinates _assignWordCoordinates;
        private readonly TryWordPlacement _tryWordPlacement;
        public SetLocations(Random random, AssignStartPoint assignStartPoint, CheckBoundary checkBoundary, AssignWordCoordinates assignWordCoordinates, TryWordPlacement tryWordPlacement)
        {
            _random = random;
            _assignStartPoint = assignStartPoint;
            _checkBoundary = checkBoundary;
            _assignWordCoordinates = assignWordCoordinates;
            _tryWordPlacement = tryWordPlacement;
        }

        public bool Locations(List<string> WordsList, List<char[]> Grid)
        {
            int gridSize = Grid.Count;

            for(int i = 0; i < WordsList.Count; i++)
            {
                int wordLength = WordsList[i].Length;

                List<(int, int)> Coordinates = new List<(int, int)>();

                    do{
                        int direction = _random.Next(1, 6);
                        if(direction == 5)
                        {
                            direction = _random.Next(5, 9);
                        }

                        var (yLocation, xLocation) = _assignStartPoint.AssignStart(gridSize);

                        (yLocation, xLocation) = _checkBoundary.Check(wordLength, gridSize, yLocation, xLocation, direction);

                        Coordinates = _assignWordCoordinates.AssignCoordinates(wordLength, yLocation, xLocation, direction);

                    } while(!_tryWordPlacement.TryPlacement(Grid, Coordinates, WordsList[i]));

            }

            return true;
        }
    }
}
