using BluePrismExercise.Models;
using System.Threading.Tasks;

namespace BluePrismExercise.Interfaces
{
    public interface IWordService
    {
        Task<Word> Run(string startWord, string endWord);
    }
}
