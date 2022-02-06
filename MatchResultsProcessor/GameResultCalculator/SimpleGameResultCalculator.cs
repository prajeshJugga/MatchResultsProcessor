using MatchResultsProcessor.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.GameResultProcessors
{
    public class SimpleGameResultCalculator : IGameResultCalculator
    {
        public void DetermineGameResult(List<GameResultDTO> gameResultsDTO)
        {
            foreach (var gameResult in gameResultsDTO)
            {
                SetGameResult(gameResult);
            }
        }

        private void SetGameResult(GameResultDTO gameResult)
        {
            if (gameResult.TeamA.GoalsScored > gameResult.TeamB.GoalsScored)
            {
                gameResult.TeamA.TeamResult = Enums.TeamResult.WIN;
                gameResult.TeamB.TeamResult = Enums.TeamResult.LOSS;
            }
            else if (gameResult.TeamA.GoalsScored < gameResult.TeamB.GoalsScored)
            {
                gameResult.TeamA.TeamResult = Enums.TeamResult.LOSS;
                gameResult.TeamB.TeamResult = Enums.TeamResult.WIN;
            }
            else
            {
                gameResult.TeamA.TeamResult = Enums.TeamResult.DRAW;
                gameResult.TeamB.TeamResult = Enums.TeamResult.DRAW;
            }
        }

    }
}
