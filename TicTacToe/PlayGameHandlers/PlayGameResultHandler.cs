using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.PlayGameHandlers
{
    public class PlayGameResultHandler : PlayGameHandler
    {
        public override void HandlePlayGameRequest(IGameDisplay display, IBoard board)
        {
            var result = board.GetResult();
            if (result != null)
            {
                display.WinMessage((char)result);
            }
            else
            {
                display.DrawMessage();
            }

            if (_successor != null)
            {
                _successor.HandlePlayGameRequest(display, board);
            }
        }
    }
}
