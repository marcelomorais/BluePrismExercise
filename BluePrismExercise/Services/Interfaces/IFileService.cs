using System.Collections.Generic;
using System.Threading.Tasks;

namespace BluePrismExercise.Interfaces
{
    public interface IFileService
    {
        Task<List<string>> ReadDictionaryFile(string dictionaryFile);
        Task SaveToFile(string resultPath, string output);
    }
}
