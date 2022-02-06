using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.Enums;
using MatchResultsProcessor.GameResultProcessors;
using NUnit.Framework;
using System.Collections.Generic;

namespace GameResultCalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Successfully_Calculates_Game_Result ()
        {
            // Arrange
            SimpleGameResultCalculator simpleGameResultCalculator = new SimpleGameResultCalculator();
            List<GameResultDTO> inputGameResults = GetInputGameResults();
            List<GameResultDTO> expectedGameResults = GetExpectedResults();
            // Act
            simpleGameResultCalculator.DetermineGameResult(inputGameResults);
            // Assert
            Assert.AreEqual(inputGameResults.Count, expectedGameResults.Count);
            for (int i = 0; i < inputGameResults.Count; i++)
            {
                Assert.AreEqual(expectedGameResults[i].TeamA.Team.Name, inputGameResults[i].TeamA.Team.Name);
                Assert.AreEqual(expectedGameResults[i].TeamA.GoalsScored, inputGameResults[i].TeamA.GoalsScored);
                Assert.AreEqual(expectedGameResults[i].TeamA.TeamResult, inputGameResults[i].TeamA.TeamResult);

                Assert.AreEqual(expectedGameResults[i].TeamB.Team.Name, inputGameResults[i].TeamB.Team.Name);
                Assert.AreEqual(expectedGameResults[i].TeamB.GoalsScored, inputGameResults[i].TeamB.GoalsScored);
                Assert.AreEqual(expectedGameResults[i].TeamB.TeamResult, inputGameResults[i].TeamB.TeamResult);
            }
        }

        private List<GameResultDTO> GetInputGameResults()
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

        private List<GameResultDTO> GetExpectedResults()
        {
            return new List<GameResultDTO>
            {
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Lions" },
                         GoalsScored = 3,
                         TeamResult = TeamResult.DRAW
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Snakes" },
                         GoalsScored = 3,
                         TeamResult = TeamResult.DRAW
                     }
                },
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Tarantulas" },
                         GoalsScored = 1,
                         TeamResult = TeamResult.WIN
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "FC Awesome" },
                         GoalsScored = 0,
                         TeamResult = TeamResult.LOSS
                     }
                },
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Lions" },
                         GoalsScored = 1,
                         TeamResult = TeamResult.DRAW
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "FC Awesome" },
                         GoalsScored = 1,
                         TeamResult = TeamResult.DRAW
                     }
                },
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name ="Tarantulas" },
                         GoalsScored = 3,
                         TeamResult = TeamResult.WIN
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name ="Snakes" },
                         GoalsScored = 1,
                         TeamResult = TeamResult.LOSS
                     }
                },
                new GameResultDTO
                {
                     TeamA = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name ="Lions" },
                         GoalsScored = 4,
                         TeamResult = TeamResult.WIN
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name ="Grouches" },
                         GoalsScored = 0,
                         TeamResult = TeamResult.LOSS
                     }
                }
            };
        }

    }
}