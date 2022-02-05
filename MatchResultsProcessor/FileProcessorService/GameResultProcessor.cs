using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.FileObjects;
using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchResultsProcessor.FileProcessorService
{
    public class GameResultProcessor : IFileProcessorService<GameResultLine, GameDetailsDTO>
    {
        public List<GameDetailsDTO> ProcessFile(List<GameResultLine> inputObjects)
        {
            List<GameDetailsDTO> gameDetailsDTOs = new List<GameDetailsDTO>();
            foreach (var inputLine in inputObjects)
            {
                string[] teamResultStrings = GetTeamResultStrings(inputLine);
                gameDetailsDTOs.Add(new GameDetailsDTO { TeamA = GetTeamStatisticDTO(teamResultStrings.First()), TeamB = GetTeamStatisticDTO(teamResultStrings.Last()) });
            }
            return gameDetailsDTOs;
        }

        private string[] GetTeamResultStrings(GameResultLine inputLine)
        {
            return inputLine.GameResult.Split(",").Select(i => i.Trim()).ToArray();
        }

        private TeamStatisticDTO GetTeamStatisticDTO(string teamResult)
        {
            return new TeamStatisticDTO
            {
                TeamName = GetTeamName(teamResult),
                GoalsScored = GetGoalsScored(teamResult)
            };
        }

        private string GetTeamName(string teamResult)
        {
            return teamResult.Substring(0, teamResult.Length - 2).Trim();
        }

        private int GetGoalsScored(string teamResult)
        {
            if (int.TryParse(teamResult.Last().ToString(), out int goalsScored))
            {
                return goalsScored;
            }
            else
            {
                throw new InvalidGameLineException();
            }
        }
    }
}
