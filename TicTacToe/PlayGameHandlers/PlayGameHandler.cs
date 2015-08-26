using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.PlayGameHandlers
{
    public abstract class PlayGameHandler
    {
        protected PlayGameHandler _successor;

        public abstract void HandlePlayGameRequest(IGameDisplay display, IBoard board);

        public void SetSuccessor(PlayGameHandler successor)
        {
            _successor = successor;
        }
    }
}
