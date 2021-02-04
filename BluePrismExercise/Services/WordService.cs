using BluePrismExercise.Interfaces;
using BluePrismExercise.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluePrismExercise.Services
{
    public class WordService : IWordService
    {
        private string startWord;

        private string endWord;

        private IFileService _fileProcessor;
        private ITextWriter _writer;
        private List<string> words;

        public WordService(IFileService fileProcessor, ITextWriter textWriter)
        {
            _fileProcessor = fileProcessor;
            _writer = textWriter;
        }

        public async Task<Word> Run(string startWord, string endWord)
        {
            this.startWord = startWord.ToUpper();
            this.endWord = endWord.ToUpper();
            words = await _fileProcessor.ReadDictionaryFile("words-english.txt");

            if (!CheckWordsExist(startWord, endWord))
            {
                _writer.WriteLine("The words could not be found in the dictionary");
                return null;
            }
            if (!CheckWordsAreOfLength(startWord, endWord, 4))
            {
                _writer.WriteLine("The words are not of length 4");
                return null;
            }

            var responseWord = CompleteWords(new Word(this.startWord));
            return responseWord;
        }

        private List<string> GetNextMatches(string word)
        {
            var mismatches = GetMismatchIndexes(word);
            var matches = GetWordsWhichDifferByOneIndex(word);
            var bestMatches = new List<string>();
            foreach (var match in matches)
            {
                if (!(GetMismatchIndexes(match).Length >= mismatches.Length))
                    bestMatches.Add(match);
            }
            if (bestMatches.Count > 0)
            {
                int min = bestMatches.Min(x => GetMismatchIndexes(x).Length);
                return bestMatches.Where(x => GetMismatchIndexes(x).Length == min).ToList();
            }
            return new List<string>();
        }

        private Word CompleteWords(Word word)
        {
            var matches = GetNextMatches(word.word);
            if (matches.Count > 0)
            {
                foreach (var match in matches)
                {
                    var newWord = new Word(match.ToUpper(), null);
                    word.Next.Add(newWord);
                    CompleteWords(newWord);
                }
            }
            return word;

        }

        private bool CheckWordsExist(string wordOne, string wordTwo)
        {
            return DoesWordExist(wordOne) && DoesWordExist(wordTwo);
        }

        private bool CheckWordsAreOfLength(string wordOne, string wordTwo, int length)
        {
            if (wordOne.Length == length && wordTwo.Length == length)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfDiffersByOneIndex(string word, string currentWord)
        {
            var diff = 0;
            if (word.Length == currentWord.Length)
            {
                for (var i = 0; i < word.Length; i++)
                {
                    if (word.ToUpper()[i] != currentWord.ToUpper()[i])
                        diff++;
                }
            }
            if (diff == 1)
                return true;
            return false;
        }

        private int[] GetMismatchIndexes(string word)
        {
            var result = new List<int>();
            for (int x = 0; x < word.Length; x++)
            {
                if (word.ToUpper()[x] != endWord.ToUpper()[x])
                    result.Add(x);
            }
            return result.ToArray();
        }

        private bool DoesWordExist(string word)
        {
            foreach (var line in words)
            {
                if (line.ToUpper() == word.ToUpper())
                    return true;
            }
            return false;
        }

        private string[] GetWordsWhichDifferByOneIndex(string word)
        {
            var result = words.Where(x => CheckIfDiffersByOneIndex(x, word));
            return result.ToArray();
        }
    }
}
