using MyResource.Core.WordSearch.Interfaces;
using MyResource.Core.WordSearch.Logic.Grid;
using MyResource.Core.WordSearch.Logic.Locations;
using MyResource.Core.WordSearch.Models;

namespace MyResource.Core.WordSearch.Logic
{
    public class CreatePuzzle : ICreatePuzzle
    {
        private readonly CreateEmptyGrid _createEmptyGrid;
        private readonly FillEmptyGrid _fillEmptyGrid;
        private readonly SetLocations _setLocations;
        public CreatePuzzle(CreateEmptyGrid createEmptyGrid, FillEmptyGrid fillEmptyGrid, SetLocations setLocations)
        {
            _createEmptyGrid = createEmptyGrid;
            _fillEmptyGrid = fillEmptyGrid;
            _setLocations = setLocations;
        }

        public (bool, List<char[]>?) Create(WordSearchModel wordSearch)
        {
            for(int i = 0; i < wordSearch.Words.Count; i++)
            {
                wordSearch.Words[i] = wordSearch.Words[i].ToUpper().Trim();
            }

            wordSearch.Words.Sort((word1, word2) => word2.Length.CompareTo(word1.Length));

            List<char[]> Grid = _createEmptyGrid.CreateGrid(wordSearch.GridSize);

            while(!_setLocations.Locations(wordSearch.Words, Grid))
            {
                Grid = _createEmptyGrid.CreateGrid(wordSearch.GridSize);
            }

            _fillEmptyGrid.FillGrid(Grid);

            return (true, Grid);
        }
    }
}