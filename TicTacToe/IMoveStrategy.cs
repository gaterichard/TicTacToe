using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IMoveStrategy
    {
        void Move(char player, IBoard board);
    }
}
