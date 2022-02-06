using MatchResultsProcessor.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchResultsProcessor.GameResultProcessors
{
    public interface IGameResultCalculator
    {
        void DetermineGameResult(List<GameResultDTO> gameResultsDTO);
    }
}
