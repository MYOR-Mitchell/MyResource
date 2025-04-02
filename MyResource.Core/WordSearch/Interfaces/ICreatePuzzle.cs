using MyResource.Core.WordSearch.Models;

namespace MyResource.Core.WordSearch.Interfaces
{
    public interface ICreatePuzzle
    {
        (bool, List<char[]>) Create(WordSearchModel wordSearch);
    }
}

