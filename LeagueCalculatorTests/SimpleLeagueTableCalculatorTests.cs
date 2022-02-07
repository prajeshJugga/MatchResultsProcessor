using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.Enums;
using MatchResultsProcessor.GameResultProcessors;
using MatchResultsProcessor.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeagueCalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Successfully_Calculates_League_Table_Correctly()
        {
            // Arrange
            GamePoints standardGamePoints = new GamePoints
            {
                WinningPoints = 3,
                DrawingPoints = 1,
                LosingPoints = 0
            };
            SimpleGameResultCalculator simpleGameResultCalculator = new SimpleGameResultCalculator();
            ILeagueTableCalculator<GameResultDTO, SimpleLeagueTableRowDTO> simpleLeagueTableCalculator = new SimpleLeagueTableCalculator(simpleGameResultCalculator, standardGamePoints);
            List<GameResultDTO> gameDetails = GetInputGameResults();
            List<SimpleLeagueTableRowDTO> expectedLeagueTable = GetExpectedLeagueTable();
            // Act
            List<SimpleLeagueTableRowDTO> calculatedLeagueTable = simpleLeagueTableCalculator.GetLeagueTable(gameDetails);
            simpleLeagueTableCalculator.GetLeagueTable(gameDetails);
            // Assert
            Assert.AreEqual(expectedLeagueTable.Count, calculatedLeagueTable.Count);
            for (int i = 0; i < calculatedLeagueTable.Count; i++)
            {
                Console.WriteLine(calculatedLeagueTable[i].LeaguePosition + ". " + calculatedLeagueTable[i].TeamName + ", " + calculatedLeagueTable[i].Points + " pts");
                Assert.AreEqual(expectedLeagueTable[i].TeamName, calculatedLeagueTable[i].TeamName);
                Assert.AreEqual(expectedLeagueTable[i].Points, calculatedLeagueTable[i].Points);
                Assert.AreEqual(expectedLeagueTable[i].LeaguePosition, calculatedLeagueTable[i].LeaguePosition);
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

        private List<SimpleLeagueTableRowDTO> GetExpectedLeagueTable()
        {
            return new List<SimpleLeagueTableRowDTO>
            {
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Tarantulas",
                    Points = 6,
                    GamesPlayed = 1,
                    LeaguePosition = 1
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Lions",
                    Points = 5,
                    GamesPlayed = 2,
                    LeaguePosition = 2
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "FC Awesome",
                    Points = 1,
                    GamesPlayed = 3,
                    LeaguePosition = 3
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Snakes",
                    Points = 1,
                    GamesPlayed = 4,
                    LeaguePosition = 3
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Grouches",
                    Points = 0,
                    GamesPlayed = 5,
                    LeaguePosition = 5
                }
            };
        }
    }
}