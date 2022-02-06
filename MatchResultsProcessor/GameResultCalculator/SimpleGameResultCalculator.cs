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

            }
        }
    }
}
