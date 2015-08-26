using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum BoardState { InPlay, Win, Draw };

    public class Board : TicTacToe.IBoard
    {
        private char[] _boardLayout;
        private char _currentPlayer = 'X';

        public Board()
        {
            _boardLayout = new char [] {'0','1','2','3','4','5','6','7','8'};
        }


        public void BoardLayout (char[] boardLayout)
        {
            _boardLayout = boardLayout;
        }

        public void Reset() {
            _boardLayout = new char [] {'0','1','2','3','4','5','6','7','8'};
        }

        public BoardState State()
        {
            if ((_boardLayout[0] == _boardLayout[1] && _boardLayout[1] == _boardLayout[2]) ||
                (_boardLayout[3] == _boardLayout[4] && _boardLayout[4] == _boardLayout[5]) ||
                (_boardLayout[6] == _boardLayout[7] && _boardLayout[7] == _boardLayout[8]) ||
                (_boardLayout[0] == _boardLayout[3] && _boardLayout[3] == _boardLayout[6]) ||
                (_boardLayout[1] == _boardLayout[4] && _boardLayout[4] == _boardLayout[7]) ||
                (_boardLayout[2] == _boardLayout[5] && _boardLayout[5] == _boardLayout[8]) ||
                (_boardLayout[0] == _boardLayout[4] && _boardLayout[4] == _boardLayout[8]) ||
                (_boardLayout[2] == _boardLayout[4] && _boardLayout[4] == _boardLayout[6]))
            {
                return BoardState.Win;
            }

            if (_boardLayout[0] != '0' && _boardLayout[1] != '1' && _boardLayout[2] != '2' &&
                _boardLayout[3] != '3' && _boardLayout[4] != '4' && _boardLayout[5] != '5' &&
                _boardLayout[6] != '6' && _boardLayout[7] != '1' && _boardLayout[8] != '8')
            {
                return BoardState.Draw;
            }
            else
            {
                return BoardState.InPlay;
            }
        }

        public char[] GetBoardLayout()
        {
            return _boardLayout;
        }

        public void SetSpace(char player, int space)
        {
            if (_boardLayout[space] == 'X' || _boardLayout[space] == 'O')
                throw new IllegalMoveException("Space already taken.");
            _currentPlayer = player;
            _boardLayout[space] = player;
        }

        public char[] GetFreeSpaces()
        {
            return _boardLayout.Where(x => x != 'X' && x != 'O').ToArray();
        }

        public bool IsInPlay()
        {
            return State() == BoardState.InPlay;
        }

        public char? GetResult()
        {
            if (IsInPlay())
            {
                throw new GameStillInPlayException("The Game Is Still In Play.");
            }

            if (State() == BoardState.Draw)
                return null;

            return _currentPlayer;
        }
    }
}
