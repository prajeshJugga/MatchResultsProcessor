using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.DTOs
{
    public class GamePoints : IDto
    {
        public double WinningPoints { get; set; }
        public double LosingPoints { get; set; }
        public double DrawingPoints { get; set; }
    }
}
