using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class RandomMoveStrategy : IMoveStrategy
    {
        public void Move(char player, IBoard board)
        {
            var freeSpaces = board.GetFreeSpaces();
            Random rnd = new Random();
            int r = rnd.Next(freeSpaces.Length);
            board.SetSpace(player, (int)Char.GetNumericValue(freeSpaces[r]));
        }
    }
}
