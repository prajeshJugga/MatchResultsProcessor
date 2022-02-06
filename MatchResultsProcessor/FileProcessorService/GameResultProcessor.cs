using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.FileObjects;
using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchResultsProcessor.FileProcessorService
{
    public class GameResultProcessor : IFileProcessorService<GameResultLine, GameResultDTO>
    {
        public List<GameResultDTO> ProcessFile(List<GameResultLine> inputObjects)
        {
            List<GameResultDTO> gameDetailsDTOs = new List<GameResultDTO>();
            foreach (var inputLine in inputObjects)
            {
                string[] teamResultStrings = GetTeamResultStrings(inputLine);
                gameDetailsDTOs.Add(new GameResultDTO { TeamA = GetTeamStatisticDTO(teamResultStrings.First()), TeamB = GetTeamStatisticDTO(teamResultStrings.Last()) });
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
                Team = new TeamDTO { Name = GetTeamName(teamResult) },
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
