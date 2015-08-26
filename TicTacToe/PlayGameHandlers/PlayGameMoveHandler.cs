using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe.PlayGameHandlers
{
    public class PlayGameMoveHandler : PlayGameHandler
    {
        IMoveStrategy _moveStrategy;
        public PlayGameMoveHandler(IMoveStrategy moveStrategy)
        {
            _moveStrategy = moveStrategy;
        }

        public override void HandlePlayGameRequest(IGameDisplay display, IBoard board)
        {
            int turn = 0;
            do
            {
                turn++;
                var player = turn % 2 == 0 ? 'O' : 'X';
                display.TurnMessage(turn);
                _moveStrategy.Move(player, board);
                display.DrawBoard(board);
                Thread.Sleep(1000);
            } while (board.IsInPlay());

            if (_successor != null)
            {
                _successor.HandlePlayGameRequest(display, board);
            }
        }
    }
}
