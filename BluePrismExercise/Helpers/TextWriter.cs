using BluePrismExercise.Interfaces;
using System;

namespace BluePrismExercise.Helpers
{
    public class TextWriter : ITextWriter
    {
        public TextWriter()
        {

        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
