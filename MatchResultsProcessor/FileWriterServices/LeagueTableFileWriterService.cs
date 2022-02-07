using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FileWriterTests
{
    public abstract class LeagueTableFileWriterService<LeagueTableRow> : IFileWriterService<LeagueTableRowLine>
    where LeagueTableRow : LeagueTableRowDTO
    {
        private readonly List<LeagueTableRow> _leagueTableRows;
        public LeagueTableFileWriterService(List<LeagueTableRow> leagueTableRows)
        {
            _leagueTableRows = leagueTableRows;
        }

        public List<LeagueTableRowLine> GetOutputFileLines()
        {
            return _leagueTableRows.Select(i => new LeagueTableRowLine { OutputFileLine = GetOutputFileLine(i) }).ToList();
        }

        public void WriteFile(string outputFilePath)
        {

        }

        protected string GetOutputFileLine(LeagueTableRow leagueTableRow)
        {
            if (leagueTableRow.Points == 1)
            {
                return string.Format("{0}. {1}, {2} pt", leagueTableRow.LeaguePosition, leagueTableRow.TeamName, leagueTableRow.Points);
            }
            return string.Format("{0}. {1}, {2} pts", leagueTableRow.LeaguePosition, leagueTableRow.TeamName, leagueTableRow.Points);
        }
    }
}