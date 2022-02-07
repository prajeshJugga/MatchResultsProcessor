using FileWriterTests;
using MatchResultsProcessor.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MatchResultsProcessor.FileWriterServices
{
    public class SimpleLeagueTableFileWriterService : LeagueTableFileWriterService<SimpleLeagueTableRowDTO>
    {
        public SimpleLeagueTableFileWriterService(List<SimpleLeagueTableRowDTO> leagueTableRows) : base(leagueTableRows)
        {
        }

        public new async void WriteFile(string outputFilePath)
        {
            using StreamWriter file = new StreamWriter(outputFilePath);
            foreach (var line in GetOutputFileLines())
            {
                await file.WriteLineAsync(line.OutputFileLine);
            }
        }
    }
}
