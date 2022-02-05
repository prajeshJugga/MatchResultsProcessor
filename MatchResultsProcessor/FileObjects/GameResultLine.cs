using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.FileObjects
{
    public class GameResultLine : IFileObject
    {
        public string GameResult { get; set; }
    }
}
