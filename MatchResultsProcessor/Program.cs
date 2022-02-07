using LeagueCalculatorTests;
using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.FileObjects;
using MatchResultsProcessor.FileProcessorService;
using MatchResultsProcessor.FileReaderServices;
using MatchResultsProcessor.FileWriterServices;
using MatchResultsProcessor.GameResultProcessors;
using System;
using System.Collections.Generic;

namespace MatchResultsProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert a file path");
            string filePath = args[0];
            GameResultFileReaderService gameResultFileReaderService = new GameResultFileReaderService();
            List<GameResultLine> gameResultsFiles = gameResultFileReaderService.GetFileObjects(filePath);
            GameResultProcessor gameResultProcessor = new GameResultProcessor();
            List<GameResultDTO> gameDetailsList = gameResultProcessor.ProcessFile(gameResultsFiles);
            GamePoints standardGamePoints = new GamePoints
            {
                WinningPoints = 3,
                DrawingPoints = 1,
                LosingPoints = 0
            };
            SimpleGameResultCalculator simpleGameResultCalculator = new SimpleGameResultCalculator();
            SimpleLeagueTableCalculator simpleLeagueTableCalculator = new SimpleLeagueTableCalculator(simpleGameResultCalculator, standardGamePoints);
            List<SimpleLeagueTableRowDTO> calculatedLeagueTable = simpleLeagueTableCalculator.GetLeagueTable(gameDetailsList);
            SimpleLeagueTableFileWriterService leagueTableFileWriterService = new SimpleLeagueTableFileWriterService(calculatedLeagueTable);
            leagueTableFileWriterService.WriteFile("league_table_" + DateTime.Now.ToString("ddMMyy_HHmmss") + ".txt");
            Console.ReadKey();
        }
    }
}
