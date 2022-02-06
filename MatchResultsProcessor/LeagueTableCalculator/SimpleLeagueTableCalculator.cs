using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.Interfaces;
using System.Collections.Generic;

namespace LeagueCalculatorTests
{
    public class SimpleLeagueTableCalculator : ILeagueTableCalculator<GameDetailsDTO, SimpleLeagueTableRowDTO>
    {
        public List<SimpleLeagueTableRowDTO> GetLeagueTable(List<GameDetailsDTO> gameDetailsDTOs)
        {
            throw new System.NotImplementedException();
        }

        private List<string> GetDistinctTeams(List<GameDetailsDTO> gameDetailsDTOs)
        {

        }
    }
}