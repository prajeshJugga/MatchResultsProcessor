using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.DTOs
{
    public class LeagueTableRowLine : IFileObject
    {
        //public int LeaguePosition { get; set; }
        //public string TeamName { get; set; }
        //public double Points { get; set; }
        public string OutputFileLine { get; set; }
    }
}
