using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.FileObjects;
using MatchResultsProcessor.FileProcessorService;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FileProcessorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Successfully_Extracts_GameResult_From_FileObject()
        {
            // Arrange
            GameResultProcessor gameResultProcessor = new GameResultProcessor();
            List<GameResultLine> gameResultLines = GetGameResultLines();
            List<GameResultDTO> expectedResults = GetExpectedResults();
            // Act
            List<GameResultDTO> gameDetailsList = gameResultProcessor.ProcessFile(gameResultLines);
            // Assert
            Assert.AreEqual(expectedResults.Count, gameDetailsList.Count);
            for (int i = 0; i < gameDetailsList.Count; i++)
            {
                Assert.AreEqual(expectedResults[i].TeamA.Team.Name, gameDetailsList[i].TeamA.Team.Name);
                Assert.AreEqual(expectedResults[i].TeamA.GoalsScored, gameDetailsList[i].TeamA.GoalsScored);

                Assert.AreEqual(expectedResults[i].TeamB.Team.Name, gameDetailsList[i].TeamB.Team.Name);
                Assert.AreEqual(expectedResults[i].TeamB.GoalsScored, gameDetailsList[i].TeamB.GoalsScored);

            }
        }

        private List<GameResultDTO> GetExpectedResults()
        {
            return new List<GameResultDTO>
            {
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Lions" },
                         GoalsScored = 3
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Snakes" },
                         GoalsScored = 3
                     }
                },
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Tarantulas" },
                         GoalsScored = 1
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "FC Awesome" },
                         GoalsScored = 0
                     }
                },
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Lions" },
                         GoalsScored = 1
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "FC Awesome" },
                         GoalsScored = 1
                     }
                },
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name ="Tarantulas" },
                         GoalsScored = 3
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name ="Snakes" },
                         GoalsScored = 1
                     }
                },
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name ="Lions" },
                         GoalsScored = 4
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name ="Grouches" },
                         GoalsScored = 0
                     }
                }
            };
        }

        private List<GameResultLine> GetGameResultLines()
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