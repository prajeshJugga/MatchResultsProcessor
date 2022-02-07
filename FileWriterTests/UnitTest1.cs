using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FileWriterTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Successfully_Writes_League_Table_To_File()
        {
            // Arrange
            List<SimpleLeagueTableRowDTO> simpleLeagueTableRowDTOs = GetLeagueTable();
            MockLeagueTableFileWriterService leagueTableFileWriterService = new MockLeagueTableFileWriterService(simpleLeagueTableRowDTOs);
            List<LeagueTableRowLine> getExpectedRowLines = GetExpectedRowLines();
            // Act
            var lines = leagueTableFileWriterService.GetOutputFileLines();
            // Assert
            Assert.AreEqual(getExpectedRowLines.Count, lines.Count);
            for (int i = 0; i < getExpectedRowLines.Count; i++)
            {
                Assert.AreEqual(getExpectedRowLines[i].OutputFileLine, lines[i].OutputFileLine);
            }
        }

        private List<SimpleLeagueTableRowDTO> GetLeagueTable()
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

        private List<LeagueTableRowLine> GetExpectedRowLines()
        {
            return new List<LeagueTableRowLine>
            {
                new LeagueTableRowLine
                {
                    OutputFileLine = "1. Tarantulas, 6 pts"
                },
                new LeagueTableRowLine
                {
                    OutputFileLine = "2. Lions, 5 pts"
                },
                new LeagueTableRowLine
                {
                    OutputFileLine = "3. FC Awesome, 1 pt"
                },
                new LeagueTableRowLine
                {
                    OutputFileLine = "3. Snakes, 1 pt"
                },
                new LeagueTableRowLine
                {
                    OutputFileLine = "5. Grouches, 0 pts"
                }
            };
        }

    }
}