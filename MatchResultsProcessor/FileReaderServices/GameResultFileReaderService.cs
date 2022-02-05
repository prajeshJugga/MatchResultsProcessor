using MatchResultsProcessor.FileObjects;
using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MatchResultsProcessor.FileReaderServices
{
    public class GameResultFileReaderService : IFileReader<GameResultsLine> // where T : IFileObject
    {
        public List<GameResultsLine> GetFileObjects(string FilePath)
        {
            return File.ReadAllLines(FilePath)
                       .Select(i => new GameResultsLine() { GameResult = i.Trim() })
                       .ToList();
        }
    }
}
