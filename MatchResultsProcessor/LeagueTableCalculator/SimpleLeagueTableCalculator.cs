using MatchResultsProcessor.DTOs;
using MatchResultsProcessor.Enums;
using MatchResultsProcessor.GameResultProcessors;
using MatchResultsProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueCalculatorTests
{
    public class SimpleLeagueTableCalculator : ILeagueTableCalculator<GameResultDTO, SimpleLeagueTableRowDTO>
    {
        private readonly IGameResultCalculator _gameResultCalculator;
        private readonly GamePoints _gamePoints;

        public SimpleLeagueTableCalculator(IGameResultCalculator gameResultCalculator, GamePoints gamePoints)
        {
            _gameResultCalculator = gameResultCalculator;
            _gamePoints = gamePoints;
        }

        public List<SimpleLeagueTableRowDTO> GetLeagueTable(List<GameResultDTO> gameResults)
        {
            _gameResultCalculator.DetermineGameResult(gameResults);
            List<SimpleLeagueTableRowDTO> leagueTableRows = new List<SimpleLeagueTableRowDTO>();
            List<TeamDTO> distinctTeams = GetDistinctTeams(gameResults);
            foreach (var team in distinctTeams)
            {
                SimpleLeagueTableRowDTO leagueTableRow = new SimpleLeagueTableRowDTO
                {
                    TeamName = team.Name
                };
                List<GameResultDTO> teamGameResults = gameResults.Where(i => IsSameTeam(i, team)).ToList();
                foreach (var gameResult in teamGameResults)
                {
                    SetTeamPoints(team, gameResult, leagueTableRow);
                }
                leagueTableRows.Add(leagueTableRow);
            }
            return GetSortedLeagueTable(leagueTableRows);
        }

        private List<SimpleLeagueTableRowDTO> GetSortedLeagueTable(List<SimpleLeagueTableRowDTO> leagueTableRows)
        {
            List<SimpleLeagueTableRowDTO> simpleLeagueTableRows = leagueTableRows.OrderByDescending(i => i.Points).ThenBy(i => i.TeamName).ToList();
            double previousPoints = 0;

            for (int i = 0; i < simpleLeagueTableRows.Count; i++)
            {
                if (IsTiedOnPoints(previousPoints, simpleLeagueTableRows[i]))
                {
                    simpleLeagueTableRows[i].LeaguePosition = simpleLeagueTableRows[i - 1].LeaguePosition;
                }
                else
                {
                    simpleLeagueTableRows[i].LeaguePosition = i + 1;
                }
                previousPoints = simpleLeagueTableRows[i].Points;
            }
            return simpleLeagueTableRows;
        }

        private bool IsTiedOnPoints(double previousPoints, SimpleLeagueTableRowDTO simpleLeagueTableRow)
        {
            return previousPoints == simpleLeagueTableRow.Points;
        }

        private void SetTeamPoints(TeamDTO team, GameResultDTO gameResult, SimpleLeagueTableRowDTO leagueTableRow)
        {
            if (IsSameTeam(gameResult.TeamA.Team, team))
            {
                leagueTableRow.Points += GetPointsForGameResult(gameResult.TeamA.TeamResult, _gamePoints);
                leagueTableRow.GamesPlayed++;
            }
            else if (IsSameTeam(gameResult.TeamB.Team, team))
            {
                leagueTableRow.Points += GetPointsForGameResult(gameResult.TeamB.TeamResult, _gamePoints);
                leagueTableRow.GamesPlayed++;
            }
        }

        private double GetPointsForGameResult(TeamResult teamResult, GamePoints gamePoints)
        {
            switch (teamResult)
            {
                case TeamResult.NOT_CALCULATED:
                    return 0;
                case TeamResult.LOSS:
                    return gamePoints.LosingPoints;
                case TeamResult.DRAW:
                    return gamePoints.DrawingPoints;
                case TeamResult.WIN:
                    return gamePoints.WinningPoints;
                default:
                    return 0;
            }
        }

        private bool IsSameTeam(GameResultDTO gameResult, TeamDTO team)
        {
            return IsSameTeam(gameResult.TeamA.Team, team) || IsSameTeam(gameResult.TeamB.Team, team);
        }

        private bool IsSameTeam(TeamDTO firstTeamToCompare, TeamDTO secondTeamToCompare)
        {
            return firstTeamToCompare.Name.Equals(secondTeamToCompare.Name, StringComparison.OrdinalIgnoreCase);
        }

        private List<TeamDTO> GetDistinctTeams(List<GameResultDTO> gameDetailsDTOs)
        {
            List<TeamDTO> distinctTeams = new List<TeamDTO>();

            foreach (var item in gameDetailsDTOs)
            {
                if (IsDistinctTeam(distinctTeams, item.TeamA.Team))
                {
                    distinctTeams.Add(item.TeamA.Team);
                }
                if (IsDistinctTeam(distinctTeams, item.TeamB.Team))
                {
                    distinctTeams.Add(item.TeamB.Team);
                }
            }

            return distinctTeams;
        }

        private bool IsDistinctTeam(List<TeamDTO> distinctTeams, TeamDTO teamToCompare)
        {
            return distinctTeams.Where(i => i.Name.Equals(teamToCompare.Name)).ToList().Count == 0;
        }
    }
}