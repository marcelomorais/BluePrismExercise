using BluePrismExercise.Interfaces;
using BluePrismExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BluePrismExercise.Tests
{
    [TestClass]
    public class WordServiceTests
    {
        [TestMethod]
        public async Task WordsNotValid_CallConsoleWriteLine_Once()
        {
            var mockFileProcessor = new Mock<IFileService>();
            mockFileProcessor.Setup(x => x.ReadDictionaryFile(It.IsAny<string>())).ReturnsAsync(new List<string>() { "pift", "paft", "zoom" });
            var mockWriter = new Mock<ITextWriter>();
            var output = new StringWriter();
            Console.SetOut(output);

            var wordProcessor = new WordService(mockFileProcessor.Object, mockWriter.Object);
            await wordProcessor.Run("blaa", "paft");

            mockWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task WordsTooLong_CallConsoleWriteLine_Once()
        {
            var mockFileProcessor = new Mock<IFileService>();
            mockFileProcessor.Setup(x => x.ReadDictionaryFile(It.IsAny<string>())).ReturnsAsync(new List<string>() { "pift", "paft", "zoom" });
            var mockWriter = new Mock<ITextWriter>();
            var output = new StringWriter();
            Console.SetOut(output);

            var wordProcessor = new WordService(mockFileProcessor.Object, mockWriter.Object);
            await wordProcessor.Run("ararararara", "paft");

            mockWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}
