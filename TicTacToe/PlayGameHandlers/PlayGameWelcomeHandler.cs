using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.PlayGameHandlers
{
    public class PlayGameWelcomeHandler : PlayGameHandler
    {
        public override void HandlePlayGameRequest(IGameDisplay display, IBoard board)
        {
            display.WelcomeMessage();
            if (_successor != null)
            {
                _successor.HandlePlayGameRequest(display, board);
            }
        }
    }
}
