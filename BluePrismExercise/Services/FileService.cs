using BluePrismExercise.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BluePrismExercise.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
        }

        public async Task<List<string>> ReadDictionaryFile(string dictionaryFile)
        {
            var responseList = new List<string>();
            using (var sr = new StreamReader(dictionaryFile))
            {
                while (!sr.EndOfStream)
                {
                    responseList.Add(await sr.ReadLineAsync());
                }
            }

            return responseList;
        }

        public async Task SaveToFile(string resultPath, string output)
        {
            using (var tw = new StreamWriter(resultPath, true))
            {
                await tw.WriteLineAsync(output);
            }
        }
    }
}
