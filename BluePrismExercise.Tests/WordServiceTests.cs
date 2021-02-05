using BluePrismExercise.Interfaces;
using BluePrismExercise.Services;
using Microsoft.Extensions.Options;
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
        private Mock<IFileService> mockFileService;
        private Mock<IOptions<Configurations>> mockConfigurations;
        private Mock<ITextWriter> mockWriter;
        [TestInitialize]
        public void TestInitialize()
        {
            mockFileService = new Mock<IFileService>();
            mockConfigurations = new Mock<IOptions<Configurations>>();
            mockWriter = new Mock<ITextWriter>();

        }

        [TestMethod]
        public async Task WordsNotValid_CallConsoleWriteLine_Once()
        {

            mockFileService.Setup(x => x.ReadDictionaryFile(It.IsAny<string>())).ReturnsAsync(new List<string>() { "pift", "paft", "zoom" });
            var output = new StringWriter();
            Console.SetOut(output);

            var wordProcessor = new WordService(mockFileService.Object, mockWriter.Object, mockConfigurations.Object);
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

            var wordProcessor = new WordService(mockFileProcessor.Object, mockWriter.Object, mockConfigurations.Object);
            await wordProcessor.Run("ararararara", "paft");

            mockWriter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}
