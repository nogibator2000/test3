using System.Numerics;
using tictaktoe.Model;

namespace tictaktoe.Services
{
    public static class GamePlay
    {
        public static int Queue()
        {
            var playerID = GlobalData.Queue.LastOrDefault() + 1;
            GlobalData.Queue.Add(playerID);
            if (GlobalData.Queue.Count > 2)
            {
                var gameId = GlobalData.Games.LastOrDefault().Key + 1;
                GlobalData.PlayerGame.Add(playerID, gameId);
                GlobalData.Queue.RemoveAt(0);
                GlobalData.PlayerGame.Add(GlobalData.Queue.FirstOrDefault(), gameId);
                GlobalData.Queue.RemoveAt(0);
                GlobalData.Games.Add(gameId, new BoardModel { BoardAsset = new int[9], TurnNumber = 0, WinningCombination = 0 });
            }
            return playerID;
        }

        public static BoardModel GetGame(GameModel gameModel)
        {
            if (GlobalData.PlayerGame.ContainsKey(gameModel.Id))
            {
                return GlobalData.Games[GlobalData.PlayerGame[gameModel.Id]];
            }
            return null;
        }
            public static BoardModel MakeTurn(TurnModel input)
        {
            var gameId = GlobalData.PlayerGame.LastOrDefault(x => x.Key == input.Id).Value;
            var game = GlobalData.Games.LastOrDefault(x => x.Key == gameId).Value;
            var SecondPlayerId = GlobalData.PlayerGame.LastOrDefault(x=> x.Value == gameId).Key;
            if( game.CurrentPlayer != !(SecondPlayerId == input.Id))
            {

            }
            if (game.BoardAsset[input.TurnCell] == 0)
            {
                switch (game.CurrentPlayer)
                {
                    case true:
                        game.BoardAsset[input.TurnCell] = 1;
                        break;
                    case false:
                        game.BoardAsset[input.TurnCell] = 2;
                        break;
                }
                game.CurrentPlayer = !game.CurrentPlayer;
            }
            else
            {
                throw new ArgumentException();
            }
            if (game.BoardAsset[0] != 0 & game.BoardAsset[0] == game.BoardAsset[1] & game.BoardAsset[1] == game.BoardAsset[2])
            {
                game.TurnNumber = 0;
                game.WinningCombination = 1;
            }
            else if (game.BoardAsset[3] != 0 & game.BoardAsset    [3] == game.BoardAsset[4] & game.BoardAsset   [4] == game.BoardAsset[5])
            {
                game.TurnNumber = 0;
                game.WinningCombination = 2;
            }
            else if (game.BoardAsset[6] != 0 & game.BoardAsset[6] == game.BoardAsset[7] & game.BoardAsset[7] == game.BoardAsset[8])
            {
                game.TurnNumber = 0;
                game.WinningCombination = 3;
            }
            else if (game.BoardAsset[0] != 0 & game.BoardAsset[0] == game.BoardAsset[3] & game.BoardAsset[3] == game.BoardAsset[6])
            {
                game.TurnNumber = 0;
                game.WinningCombination = 4;
            }
            else if (game.BoardAsset[1] != 0 & game.BoardAsset[1] == game.BoardAsset[4] & game.BoardAsset[4] == game.BoardAsset[7])
            {
                game.TurnNumber = 0;
                game.WinningCombination = 5;
            }
            else if (game.BoardAsset[2] != 0 & game.BoardAsset[2] == game.BoardAsset[5] & game.BoardAsset[5] == game.BoardAsset[8])
            {
                game.TurnNumber = 0;
                game.WinningCombination = 6;
            }
            else if (game.BoardAsset[0] != 0 & game.BoardAsset[0] == game.BoardAsset[4] & game.BoardAsset[4] == game.BoardAsset[8])
            {
                game.TurnNumber = 0;
                game.WinningCombination = 7;
            }
            else if (game.BoardAsset[2] != 0 & game.BoardAsset[2] == game.BoardAsset[4] & game.BoardAsset[4] == game.BoardAsset[6])
            {
                game.TurnNumber = 0;
                game.WinningCombination = 8;
            }
            return game;
        }

    }
}
