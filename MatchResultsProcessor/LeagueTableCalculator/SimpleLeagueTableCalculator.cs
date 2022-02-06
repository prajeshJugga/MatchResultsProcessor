using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.Interfaces;
using System.Collections.Generic;

namespace LeagueCalculatorTests
{
    public class SimpleLeagueTableCalculator : ILeagueTableCalculator<GameResultDTO, SimpleLeagueTableRowDTO>
    {
        
        public List<SimpleLeagueTableRowDTO> GetLeagueTable(List<GameResultDTO> gameDetailsDTOs)
        {
            throw new System.NotImplementedException();
        }

        private List<TeamDTO> GetDistinctTeams(List<GameResultDTO> gameDetailsDTOs)
        {
            List<TeamDTO> distinctTeams = new List<TeamDTO>();

            foreach (var item in gameDetailsDTOs)
            {
                if (!distinctTeams.Contains(item.TeamA.Team))
                {
                    distinctTeams.Add(item.TeamA.Team);
                }

                if (!distinctTeams.Contains(item.TeamB.Team))
                {
                    distinctTeams.Add(item.TeamB.Team);
                }
            }

            return distinctTeams;
        }
    }
}