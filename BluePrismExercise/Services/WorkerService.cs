using BluePrismExercise.Helpers;
using BluePrismExercise.Interfaces;
using BluePrismExercise.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BluePrismExercise.Services
{
    public class WorkerService : IWorkerService
    {

        private IWordService _wordProcessor;
        private IFileService _fileService;
        private IOptions<Configurations> _config;

        public WorkerService(IWordService wordProcessor, IFileService fileService, IOptions<Configurations> config)
        {
            _wordProcessor = wordProcessor;
            _fileService = fileService;
            _config = config;
        }

        public async Task<string> Run(string startWord, string endWord)
        {
            var result = await _wordProcessor.Run(startWord, endWord);
            var path = new ShortestPath();
            var shortestPath = path.GetShortestPath(new List<Word>() { result }, endWord);
            var formattedResult = FormatResult(shortestPath);
            await _fileService.SaveToFile(_config.Value.ResultPath, formattedResult);
            return formattedResult;
        }

        private string FormatResult(List<Word> words)
        {
            if (words == null || words.Count == 0)
                return "Solution cannot be found in this dictionary";
            var toReturn = string.Empty;
            foreach (var word in words)
                toReturn += word.word + "\n";

            return toReturn;
        }
    }
}
