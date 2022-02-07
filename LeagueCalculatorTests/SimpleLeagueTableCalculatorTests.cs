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
        private GamePoints _standardGamePoints;
        private SimpleGameResultCalculator _simpleGameResultCalculator;
        private ILeagueTableCalculator<GameResultDTO, SimpleLeagueTableRowDTO> _simpleLeagueTableCalculator;

        [SetUp]
        public void Setup()
        {
            _standardGamePoints = new GamePoints
            {
                WinningPoints = 3,
                DrawingPoints = 1,
                LosingPoints = 0
            };
            _simpleGameResultCalculator = new SimpleGameResultCalculator();
            _simpleLeagueTableCalculator = new SimpleLeagueTableCalculator(_simpleGameResultCalculator, _standardGamePoints);
        }

        private void Calculate_League_Table(List<GameResultDTO> inputGameDetails, List<SimpleLeagueTableRowDTO> expectedLeagueTable, ILeagueTableCalculator<GameResultDTO, SimpleLeagueTableRowDTO> simpleLeagueTableCalculator)
        {
            // Arrange
            // Act
            List<SimpleLeagueTableRowDTO> calculatedLeagueTable = simpleLeagueTableCalculator.GetLeagueTable(inputGameDetails);
            // Assert
            Assert.AreEqual(expectedLeagueTable.Count, calculatedLeagueTable.Count);
            for (int i = 0; i < calculatedLeagueTable.Count; i++)
            {
                Assert.AreEqual(expectedLeagueTable[i].TeamName, calculatedLeagueTable[i].TeamName);
                Assert.AreEqual(expectedLeagueTable[i].Points, calculatedLeagueTable[i].Points);
                Assert.AreEqual(expectedLeagueTable[i].LeaguePosition, calculatedLeagueTable[i].LeaguePosition);
            }
        }

        [Test]
        public void Successfully_Calculates_League_Positions_For_Teams_With_Different_Points()
        {
            // Arrange
            List<GameResultDTO> inputGameDetails = GetGamesWithDifferentResults(); 
            List< SimpleLeagueTableRowDTO > expectedLeagueTable = GetExpectedLeagueTableForTeamsWithDifferentResults();
            // Act and Assert
            Calculate_League_Table(inputGameDetails, expectedLeagueTable, _simpleLeagueTableCalculator);
        }


        [Test]
        public void Successfully_Calculates_League_Positions_For_Teams_With_Same_Points()
        {
            // Arrange
            List<GameResultDTO> inputGameDetails = GetGamesWithSameResults();
            List<SimpleLeagueTableRowDTO> expectedLeagueTable = GetExpectedLeagueTableForTeamsWithSameResults();
            // Act and Assert
            Calculate_League_Table(inputGameDetails, expectedLeagueTable, _simpleLeagueTableCalculator);
        }

        private List<GameResultDTO> GetGamesWithDifferentResults()
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

        private List<SimpleLeagueTableRowDTO> GetExpectedLeagueTableForTeamsWithDifferentResults()
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

        private List<GameResultDTO> GetGamesWithSameResults()
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
                         Team = new TeamDTO { Name = "Cheetahs" },
                         GoalsScored = 1,
                         TeamResult = TeamResult.DRAW
                     },
                     TeamB = new TeamStatisticDTO
                     {
                         Team = new TeamDTO { Name = "Hyenas" },
                         GoalsScored = 1,
                         TeamResult = TeamResult.DRAW
                     }
                }
            };
        }

        private List<SimpleLeagueTableRowDTO> GetExpectedLeagueTableForTeamsWithSameResults()
        {
            return new List<SimpleLeagueTableRowDTO>
            {
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Cheetahs",
                    Points = 1,
                    GamesPlayed = 1,
                    LeaguePosition = 1
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "FC Awesome",
                    Points = 1,
                    GamesPlayed = 1,
                    LeaguePosition = 1
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Hyenas",
                    Points = 1,
                    GamesPlayed = 1,
                    LeaguePosition = 1
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Lions",
                    Points = 1,
                    GamesPlayed = 1,
                    LeaguePosition = 1
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Snakes",
                    Points = 1,
                    GamesPlayed = 1,
                    LeaguePosition = 1
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Tarantulas",
                    Points = 1,
                    GamesPlayed = 1,
                    LeaguePosition = 1
                }
            };
        }
    }
}