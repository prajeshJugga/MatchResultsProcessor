using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.DTOs
{
    public class GameResultDTO: IDto
    {
        public TeamStatisticDTO TeamA { get; set; }
        public TeamStatisticDTO TeamB { get; set; }
    }
}
