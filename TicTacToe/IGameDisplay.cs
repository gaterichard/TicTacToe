using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IGameDisplay
    {
        void WelcomeMessage();
        void DrawBoard(IBoard board);

        void TurnMessage(int turn);

        void WinMessage(char player);

        void DrawMessage();

        bool PlayAgainMessage();
    }
}
