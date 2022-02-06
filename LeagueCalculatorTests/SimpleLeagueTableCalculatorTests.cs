using MatchResultsProcessor.DTOs;
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
            ILeagueTableCalculator<GameDetailsDTO, SimpleLeagueTableRowDTO> simpleLeagueTableCalculator = new SimpleLeagueTableCalculator();
            List<GameDetailsDTO> gameDetails = new List<GameDetailsDTO>();
            List<SimpleLeagueTableRowDTO> expectedLeagueTable = GetExpectedLeagueTable();
            // Act
            List<SimpleLeagueTableRowDTO> calculatedLeagueTable = simpleLeagueTableCalculator.GetLeagueTable(gameDetails);
            // Assert
            Assert.AreEqual(expectedLeagueTable.Count, calculatedLeagueTable.Count);
            for (int i = 0; i < expectedLeagueTable.Count; i++)
            {
                Assert.AreEqual(expectedLeagueTable[i].TeamName, calculatedLeagueTable[i].TeamName);
                Assert.AreEqual(expectedLeagueTable[i].Points, calculatedLeagueTable[i].Points);
                Assert.AreEqual(expectedLeagueTable[i].LeaguePosition, calculatedLeagueTable[i].LeaguePosition);
            }
        }

        private List<SimpleLeagueTableRowDTO> GetExpectedLeagueTable()
        {
            return new List<SimpleLeagueTableRowDTO>
            {
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Tarantulas",
                    Points = 6,
                    LeaguePosition = 1
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Lions",
                    Points = 5,
                    LeaguePosition = 2
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "FC Awesome",
                    Points = 1,
                    LeaguePosition = 3
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Snakes",
                    Points = 1,
                    LeaguePosition = 4
                },
                new SimpleLeagueTableRowDTO
                {
                    TeamName = "Grouches",
                    Points = 0,
                    LeaguePosition = 5
                }
            };
        }
    }
}