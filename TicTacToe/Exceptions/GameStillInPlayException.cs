using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameStillInPlayException : Exception
    {
        public GameStillInPlayException()
        {

        }

        public GameStillInPlayException(string message) : base (message)
        {

        }

        public GameStillInPlayException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
