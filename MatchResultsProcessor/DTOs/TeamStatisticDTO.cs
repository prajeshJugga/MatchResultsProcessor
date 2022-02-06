using MatchResultsProcessor.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.DTOs
{
    public class TeamStatisticDTO
    {
        public TeamDTO Team { get; set; }
        public int GoalsScored { get; set; }
        public TeamResult TeamResult { get; set; }
    }
}
