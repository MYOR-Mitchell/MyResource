namespace MyResource.Core.WordSearch.Logic.Locations
{
    public class AssignWordCoordinates
    {
        public List<(int, int)> AssignCoordinates(int wordLength, int yLocation, int xLocation, int direction)
        {
            List<(int, int)> Coordinates = new List<(int, int)>();

            for(int i = 0; i < wordLength; i++)
            {
                if(direction == 1) // Up
                {
                    Coordinates.Add((yLocation - i, xLocation));
                }
                else if(direction == 5) // Up, Right
                {
                    Coordinates.Add((yLocation - i, xLocation + i));
                }
                else if(direction == 2) // Right
                {
                    Coordinates.Add((yLocation, xLocation + i));
                }
                else if(direction == 6) // Down, Right
                {
                    Coordinates.Add((yLocation + i, xLocation + i));
                }
                else if(direction == 3) // Down
                {
                    Coordinates.Add((yLocation + i, xLocation));
                }
                else if(direction == 7) // Down, Left
                {
                    Coordinates.Add((yLocation + i, xLocation - i));
                }
                else if(direction == 4) // Left
                {
                    Coordinates.Add((yLocation, xLocation - i));
                }
                else if(direction == 8) // Up, Left
                {
                    Coordinates.Add((yLocation - i, xLocation - i));
                }
            }

            return Coordinates;
        }
    }
}

