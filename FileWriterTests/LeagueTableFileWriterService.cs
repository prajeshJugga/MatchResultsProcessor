using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.Interfaces;
using System.Collections.Generic;

namespace FileWriterTests
{
    public class MockLeagueTableFileWriterService : LeagueTableFileWriterService<SimpleLeagueTableRowDTO>
    {
        public MockLeagueTableFileWriterService(List<SimpleLeagueTableRowDTO> leagueTableRows) : base(leagueTableRows)
        {
        }
    }
}