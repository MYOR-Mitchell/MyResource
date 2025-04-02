namespace MyResource.Core.WordSearch.Logic.Locations
{
    public class CheckBoundary
    {
        public (int, int) Check(int wordLength, int gridSize, int yLocation, int xLocation, int direction)
        {
            if(direction == 1)
            {
                (yLocation, xLocation) = CheckUp(wordLength, gridSize, yLocation, xLocation);
            }
            else if(direction == 5)
            {
                (yLocation, xLocation) = CheckUpRight(wordLength, gridSize, yLocation, xLocation);
            }
            else if(direction == 2)
            {
                (yLocation, xLocation) = CheckRight(wordLength, gridSize, yLocation, xLocation);
            }
            else if(direction == 6)
            {
                (yLocation, xLocation) = CheckDownRight(wordLength, gridSize, yLocation, xLocation);
            }
            else if(direction == 3)
            {
                (yLocation, xLocation) = CheckDown(wordLength, gridSize, yLocation, xLocation);
            }
            else if(direction == 7)
            {
                (yLocation, xLocation) = CheckDownLeft(wordLength, gridSize, yLocation, xLocation);
            }
            else if(direction == 4)
            {
                (yLocation, xLocation) = CheckLeft(wordLength, gridSize, yLocation, xLocation);
            }
            else if(direction == 8)
            {
                (yLocation, xLocation) = CheckUpLeft(wordLength, gridSize, yLocation, xLocation);
            }

            return (yLocation, xLocation);
        }

        private (int, int) CheckUp(int wordLength, int gridSize, int yLocation, int xLocation)
        {
            if(wordLength > yLocation + 1)
            {
                yLocation = wordLength - 1;
            }

            return (yLocation, xLocation);
        }

        private (int, int) CheckUpRight(int wordLength, int gridSize, int yLocation, int xLocation)
        {
            if(wordLength > yLocation + 1)
            {
                yLocation = wordLength - 1;
            }
            if(wordLength > gridSize - xLocation)
            {
                xLocation = gridSize - wordLength;
            }

            return (yLocation, xLocation);
        }

        private (int, int) CheckRight(int wordLength, int gridSize, int yLocation, int xLocation)
        {
            if(wordLength > gridSize - xLocation)
            {
                xLocation = gridSize - wordLength;
            }

            return (yLocation, xLocation);
        }

        private (int, int) CheckDownRight(int wordLength, int gridSize, int yLocation, int xLocation)
        {
            if(wordLength > gridSize - yLocation)
            {
                yLocation = gridSize - wordLength;
            }
            if(wordLength > gridSize - xLocation)
            {
                xLocation = gridSize - wordLength;
            }

            return (yLocation, xLocation);
        }

        private (int, int) CheckDown(int wordLength, int gridSize, int yLocation, int xLocation)
        {
            if(wordLength > gridSize - yLocation)
            {
                yLocation = gridSize - wordLength;
            }

            return (yLocation, xLocation);
        }

        private (int, int) CheckDownLeft(int wordLength, int gridSize, int yLocation, int xLocation)
        {
            if(wordLength > gridSize - yLocation)
            {
                yLocation = gridSize - wordLength;
            }
            if(wordLength > xLocation)
            {
                xLocation = wordLength - 1;
            }

            return (yLocation, xLocation);
        }

        private (int, int) CheckLeft(int wordLength, int gridSize, int yLocation, int xLocation)
        {
            if(wordLength > xLocation)
            {
                xLocation = wordLength - 1;
            }

            return (yLocation, xLocation);
        }

        private (int, int) CheckUpLeft(int wordLength, int gridSize, int yLocation, int xLocation)
        {
            if(wordLength > yLocation + 1)
            {
                yLocation = wordLength - 1;
            }
            if(wordLength > xLocation)
            {
                xLocation = wordLength - 1;
            }

            return (yLocation, xLocation);
        }
    }
}
