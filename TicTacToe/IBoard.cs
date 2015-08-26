using System;
namespace TicTacToe
{
    public interface IBoard
    {
        void Reset();

        void BoardLayout(char[] boardLayout);
        char[] GetBoardLayout();
        char[] GetFreeSpaces();
        bool IsInPlay();
        void SetSpace(char player, int space);
        BoardState State();

        char? GetResult();
    }
}
