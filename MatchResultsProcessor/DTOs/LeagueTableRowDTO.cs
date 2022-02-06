using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.DTOs
{
    public abstract class LeagueTableRowDTO : IDto
    {
        public string TeamName { get; set; }
        public double Points { get; set; }
        public int GamesPlayed { get; set; }
    }
}
