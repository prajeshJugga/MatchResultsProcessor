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
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0 || args[0] == null)
                {
                    throw new ArgumentNullException(nameof(args));
                }

                string filePath = args[0];
                Console.WriteLine("Reading file at path: " + filePath);
                _logger.Info("Reading file at path: " + filePath);
                GameResultFileReaderService gameResultFileReaderService = new GameResultFileReaderService();
                List<GameResultLine> gameResultsFiles = gameResultFileReaderService.GetFileObjects(filePath);
                Console.WriteLine("Processing file into DTOs ...");
                _logger.Info("Processing file into DTOs ...");
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
                Console.WriteLine("Calculating game results and league table ...");
                _logger.Info("Calculating game results and league table ...");
                List<SimpleLeagueTableRowDTO> calculatedLeagueTable = simpleLeagueTableCalculator.GetLeagueTable(gameDetailsList);
                
                string outputFileName = GetOutputFilePath();
                Console.WriteLine("Writing league table to output file: " + outputFileName + " ...");
                _logger.Info("Writing league table to output file: " + outputFileName + " ...");
                SimpleLeagueTableFileWriterService leagueTableFileWriterService = new SimpleLeagueTableFileWriterService(calculatedLeagueTable);
                leagueTableFileWriterService.WriteFile(outputFileName);

                Console.WriteLine("Successfully processed file " + " ...");
                _logger.Info("Writing league table to output file: " + outputFileName + " ...");

                Console.ReadKey();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No input file provided, please enter an in line argument to path to the file to process. Error ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to process league table. Error ", ex.Message);
            }

        }

        private static string GetOutputFilePath()
        {
            return "league_table_" + DateTime.Now.ToString("ddMMyy_HHmmss") + ".txt";
        }
    }
}
