using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class IllegalMoveException : Exception
    {
        public IllegalMoveException()
        {

        }

        public IllegalMoveException(string message) : base (message)
        {

        }

        public IllegalMoveException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
