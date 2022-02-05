using MatchResultsProcessor.FileObjects;
using MatchResultsProcessor.FileReaderServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace FileReaderTests
{
    public class Tests
    {
        private GameResultFileReaderService _gameResultFileReaderService;
        private string _directoryPath;

        [SetUp]
        public void Setup()
        {
            _gameResultFileReaderService = new GameResultFileReaderService();
            _directoryPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

        public void Read_And_Deserialize_A_File(string filePath, int expectedLineCount, List<GameResultLine> expectedGameResultsLines)
        {
            // Arrange
            List<GameResultLine> gameResultsFiles = new List<GameResultLine>();
            // string filePath = Path.Join(Directory.GetCurrentDirectory(), "SampleFiles", "ValidFile5Results.txt");
            // Act
            gameResultsFiles = _gameResultFileReaderService.GetFileObjects(filePath);
            // Assert
            Assert.AreEqual(expectedLineCount, gameResultsFiles.Count);
            // CollectionAssert.AreEquivalent(GetExpectedResults(), gameResultsFiles);

            for (int i = 0; i < gameResultsFiles.Count; i++)
            {
                Assert.AreEqual(expectedGameResultsLines[i].GameResult, gameResultsFiles[i].GameResult);
            }
        }

        [Test]
        public void Read_And_Deserialize_A_Small_File()
        {
            // Arrange
            string filePath = Path.Join(Directory.GetCurrentDirectory(), "SampleFiles", "ValidFile5Results.txt");
            List<GameResultLine> expectedGameResultsLines = GetExpectedResultsForSmallFile();
            // Act & Assert
            Read_And_Deserialize_A_File(filePath, 5, expectedGameResultsLines);
        }

        private List<GameResultLine> GetExpectedResultsForSmallFile()
        {
            return new List<GameResultLine>()
            {
                new GameResultLine { GameResult = "Lions 3, Snakes 3" },
                new GameResultLine { GameResult = "Tarantulas 1, FC Awesome 0" },
                new GameResultLine { GameResult = "Lions 1, FC Awesome 1" },
                new GameResultLine { GameResult= "Tarantulas 3, Snakes 1" },
                new GameResultLine { GameResult= "Lions 4, Grouches 0" }
            };
        }
    }
}