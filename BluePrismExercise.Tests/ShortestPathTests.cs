using BluePrismExercise.Models;
using BluePrismExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BluePrismExercise.Tests
{
    [TestClass]
    public class ShortestPathTests
    {
        ShortestPath shortestPath;

        [TestInitialize]
        public void ShortestPathTestsSetUp()
        {
            shortestPath = new ShortestPath();
        }

        [TestMethod]
        public void TestPathWithOnlyOnePathToResultIsReturned()
        {
            var wordOne = new Word("one");
            var wordTwo = new Word("two", null);
            var wordThree = new Word("three", null);
            wordOne.Next.Add(wordTwo);
            wordTwo.Next.Add(wordThree);

            var result = shortestPath.GetShortestPath(new List<Word>() { wordOne }, "three");
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void TestPathWithMultiplePathsCorrectResultIsReturned()
        {
            var wordOne = new Word("one");
            var wordTwo = new Word("two", null);
            var wordThree = new Word("three", null);
            wordOne.Next.Add(wordTwo);
            wordTwo.Next.Add(wordThree);
            var wordFour = new Word("four", null);
            wordOne.Next.Add(wordFour);
            var wordFive = new Word("five", null);
            wordFour.Next.Add(wordFive);
            var wordSix = new Word("three", null);
            wordFive.Next.Add(wordSix);

            var result = shortestPath.GetShortestPath(new List<Word>() { wordOne }, "three");
            Assert.AreEqual(3, result.Count);
        }
    }
}
