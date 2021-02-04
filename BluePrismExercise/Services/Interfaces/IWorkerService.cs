using System.Collections.Generic;
using System.Threading.Tasks;

namespace BluePrismExercise.Interfaces
{
    public interface IWorkerService
    {
        Task<string> Run(string startWord, string endWord);
    }
}
