using MatchResultsProcessor.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.Interfaces
{
    public interface ILeagueTableCalculator<GameDetailsInput, LeagueTableRowOutput>
        where LeagueTableRowOutput : LeagueTableRowDTO
        where GameDetailsInput : GameDetailsDTO
    {
        List<LeagueTableRowOutput> GetLeagueTable(List<GameDetailsInput> gameDetailsDTOs);
    }
}
