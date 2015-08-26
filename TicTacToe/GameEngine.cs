using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.PlayGameHandlers;

namespace TicTacToe
{
    public class GameEngine
    {
        private IGameDisplay _display;
        private IBoard _board;
        private PlayGameHandler _playGameHandler;

        public GameEngine(IGameDisplay display, IBoard board, PlayGameHandler playGameHandler)
        {
            _display = display;
            _board = board;
            _playGameHandler = playGameHandler;
        }

        public void Play()
        {
            do
            {
                _board.Reset();
                _playGameHandler.HandlePlayGameRequest(_display, _board);
            } while (_display.PlayAgainMessage());
        }
    }
}
