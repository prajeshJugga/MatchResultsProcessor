using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.FileObjects
{
    public class GameResultsFile : IFileObject
    {
        public string GameResult { get; set; }
    }
}
