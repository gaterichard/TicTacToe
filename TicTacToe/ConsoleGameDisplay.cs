using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ConsoleGameDisplay : IGameDisplay
    {
        public void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to tic-tac-toe, press any key to start the game.\n");
            Console.ReadLine();
        }

        public void DrawBoard(IBoard board)
        {
            var boardLayout = board.GetBoardLayout();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", GetCellValue(boardLayout[0]), GetCellValue(boardLayout[1]), GetCellValue(boardLayout[2]));
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", GetCellValue(boardLayout[3]), GetCellValue(boardLayout[4]), GetCellValue(boardLayout[5]));
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", GetCellValue(boardLayout[6]), GetCellValue(boardLayout[7]), GetCellValue(boardLayout[8]));
            Console.WriteLine("     |     |      ");
            Console.WriteLine("\n");
        }

        private char GetCellValue(char value)
        {
            if (value == 'X' || value == 'O')
            {
                return value;
            }
            else
            {
                return '-';
            }
        }

        public void TurnMessage(int turn)
        {
            Console.WriteLine("Turn: {0}", turn);
        }

        public void WinMessage(char player)
        {
            Console.WriteLine("Player: {0} wins", player);
        }

        public void DrawMessage()
        {
            Console.WriteLine("Game Is Tied.");
        }

        public bool PlayAgainMessage()
        {
            Console.WriteLine("Press y to play the game again.");
            var again = Console.ReadLine();
            return again == "y";
        }
    }
}
