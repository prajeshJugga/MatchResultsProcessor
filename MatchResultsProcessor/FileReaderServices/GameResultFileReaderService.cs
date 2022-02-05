using MatchResultsProcessor.FileObjects;
using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MatchResultsProcessor.FileReaderServices
{
    public class GameResultFileReaderService : IFileReader<GameResultLine> // where T : IFileObject
    {
        public List<GameResultLine> GetFileObjects(string FilePath)
        {
            return File.ReadAllLines(FilePath)
                       .Select(i => new GameResultLine() { GameResult = i.Trim() })
                       .ToList();
        }
    }
}
