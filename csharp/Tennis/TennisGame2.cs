using System;
namespace Tennis
{
    //this is refactoring of well-known task https://github.com/emilybache/Tennis-Refactoring-Kata/tree/main/csharp
    //code style fixed
    //clear logic provided
    //all code compacted from 140+ lines to just 70 lines, many of which are comments and other environment around real code

    public class TennisGame2 : ITennisGame
    {
        private int _firstPlayerPoints;
        private int _secondPlayerPoints;
        private readonly string[] _pointNames ;

        public TennisGame2()
        {
            _firstPlayerPoints = _secondPlayerPoints = 0;
            _pointNames = new[] { "Love", "Fifteen", "Thirty", "Forty" };
        }

        //another algorithm introduced on the refactoring
        //split processing into 3 cases
        //case 1: equal score
        //case 2: non-equal, one player has advantage or win (more than 40)
        //case 3: non-equal, every player has score 40 or less
        //also enormous method is split into several compact methods
        public string GetScore()
        {
            string score;
            bool equalScore = _firstPlayerPoints == _secondPlayerPoints;
            bool advantageOrWin = _firstPlayerPoints >= 4 || _secondPlayerPoints >= 4;

            if (equalScore)
            {
                score = GetEqualScore();
            }
            else if (advantageOrWin)
            {
                score = GetAdvantageOrWinScore();
            }
            else 
            { 
                score = GetTransitionalScore();
            }
            return score;
        }

        private string GetEqualScore()
        {
            bool lessThanForty = _firstPlayerPoints < 3;
            return lessThanForty ? $"{_pointNames[_firstPlayerPoints]}-All" : "Deuce";
        }

        private string GetAdvantageOrWinScore()
        {
            int pointDifference = _firstPlayerPoints - _secondPlayerPoints;
            bool isWin = Math.Abs(pointDifference) >= 2;
            bool advantageFirstPlayer = pointDifference > 0;

            return isWin ? $"Win for player{(advantageFirstPlayer ? 1 : 2)}" : $"Advantage player{(advantageFirstPlayer ? 1 : 2)}";
        }
        
        private string GetTransitionalScore() => $"{_pointNames[_firstPlayerPoints]}-{_pointNames[_secondPlayerPoints]}";
        public void WonPoint(string player)
        {
            if (player == "player1")
            {
                _firstPlayerPoints++;
            }
            else
            {
                _secondPlayerPoints++;
            }
        }
    }
}