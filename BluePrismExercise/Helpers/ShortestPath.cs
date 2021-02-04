using BluePrismExercise.Models;
using System.Collections.Generic;
using System.Linq;

namespace BluePrismExercise.Helpers
{
    public class ShortestPath
    {
        public ShortestPath()
        {
        }

        private List<Word> GetShortestList(List<List<Word>> lists)
        {
            var filtered = lists.Where(x => x != null);
            var smallest = filtered.Min(x => x.Count);
            return filtered.First(x => x.Count == smallest);
        }

        public List<Word> GetShortestPath(List<Word> words, string toFind)
        {
            var currentWord = words[words.Count - 1];

            if (currentWord.Next.Count == 0)
            {
                if (currentWord.word == toFind)
                    return words;
                else
                    return null;
            }
            var allLists = new List<List<Word>>();
            foreach (var word in currentWord.Next)
            {
                var newList = new List<Word>(words);
                newList.Add(word);
                allLists.Add(GetShortestPath(newList, toFind));
            }
            return GetShortestList(allLists);
        }
    }
}

