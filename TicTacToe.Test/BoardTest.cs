using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Test
{
    [TestFixture]
    public class BoardTest
    {
        private Board _board;

        [SetUp]
        public void Setup()
        {
            _board = new Board();
        }

        [TestCase(new char[] { 'X', 'X', 'X', '3', '4', '5', '6', '7', '8' })] // horizontal row 1
        [TestCase(new char[] { '0', '1', '2', 'X', 'X', 'X', '6', '7', '8' })] // ... 2
        [TestCase(new char[] { '0', '1', '2', '3', '4', '5', 'X', 'X', 'X' })] // ... 3
        [TestCase(new char[] { 'X', '1', '2', 'X', '4', '5', 'X', '7', '8' })] // vertical row 1
        [TestCase(new char[] { '0', 'X', '2', '3', 'X', '5', '6', 'X', '8' })] // ... 2
        [TestCase(new char[] { '0', '1', 'X', '3', '4', 'X', '6', '7', 'X' })] // ... 3
        [TestCase(new char[] { 'X', '1', '2', '3', 'X', '5', '6', '7', 'X' })] // diagonal row 1
        [TestCase(new char[] { '0', '1', 'X', '3', 'X', '5', 'X', '7', '8' })] // ... 2
        public void The_Game_Is_Won_When_Three_In_A_Row_Match_Is_Found(char[] boardLayout)
        {
            _board.BoardLayout(boardLayout);
            Assert.AreEqual(BoardState.Win, _board.State());
        }

        [Test]
        public void The_Game_Is_Drawn_When_No_Three_In_A_Row_Match_Is_Found_And_All_Moves_Have_Been_Played()
        {
            _board.BoardLayout(new char[] {'X', 'X', 'O', 'O', 'O', 'X', 'X', 'O', 'X'});
            Assert.AreEqual(BoardState.Draw, _board.State());
        }

        [Test]
        public void The_Game_Is_In_Play_Whilst_There_Are_Moves_That_Can_Be_Made_And_No_Three_In_A_Row_Match()
        {
            _board.BoardLayout(new char[] { 'X', '1', 'X', 'O', '4', 'O', '6', 'O', 'X' });
            Assert.AreEqual(BoardState.InPlay, _board.State());
        }

        [Test]
        public void Making_A_Move_Updates_The_Board()
        {
            _board.SetSpace('X', 3);
            Assert.AreEqual(_board.GetBoardLayout()[3], 'X');
        }

        [Test]
        public void Marking_An_Already_Taken_Space_Throws_An_Illegal_Move_Exception()
        {
            _board.SetSpace('X', 3);
            Assert.Throws<IllegalMoveException>(() => _board.SetSpace('O', 3));
        }

        [Test]
        public void Get_Free_Spaces()
        {
            _board.BoardLayout(new char[] { 'X', '1', 'X', 'O', '4', 'O', '6', 'O', 'X' });
            Assert.AreEqual(new char[] { '1', '4', '6' }, _board.GetFreeSpaces());
        }

        [TestCase(new char[] { 'X', 'O', 'O', 'O', 'X', 'X', 'O', 'X', 'X' }, 'X')] // Win for O
        [TestCase(new char[] { 'O', 'X', 'O', 'X', 'O', 'O', 'X', 'O', 'X' }, null)] // Drawn Game
        public void Get_Result_Returns_The_Result_Of_Won_And_Drawn_Games(char[] boardLayout, char? expectedResult)
        {
            _board.BoardLayout(boardLayout);
            Assert.AreEqual(expectedResult, _board.GetResult());
        }

        [Test]
        public void Get_Result_Throws_A_Game_Still_In_Play_Exception_When_Game_Is_Still_In_Play()
        {
            _board.BoardLayout(new char[] { 'X', '1', 'X', 'O', '4', 'O', '6', 'O', 'X' });
            Assert.Throws<GameStillInPlayException>(() => _board.GetResult());
        }
    }
}
