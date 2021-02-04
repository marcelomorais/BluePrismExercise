using System.Collections.Generic;

namespace BluePrismExercise.Models
{
    public class Word
    {
        public string word { get; }

        public List<Word> Next { get; set; }

        public Word(string word, Word next = null)
        {
            this.word = word;
            Next = next == null ? new List<Word>() : new List<Word> { next };
        }
    }
}
