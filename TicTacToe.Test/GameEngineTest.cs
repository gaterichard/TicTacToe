using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.PlayGameHandlers;

namespace TicTacToe.Test
{
    [TestFixture]
    public class GameEngineTest
    {
        private GameEngine _gameEngine;
        private Mock<IGameDisplay> _display;
        private Mock<IBoard> _board;
        private Mock<PlayGameHandler> _playGameHandler;

        [SetUp]
        public void Setup()
        {
            _display = new Mock<IGameDisplay>();
            _display.SetupSequence<IGameDisplay, bool>(x => x.PlayAgainMessage()).Returns(true).Returns(true).Returns(false);
            _board = new Mock<IBoard>();
            _playGameHandler = new Mock<PlayGameHandler>();
            _gameEngine = new GameEngine(_display.Object, _board.Object, _playGameHandler.Object);
        }

        [Test]
        public void GameEngine_Resets_The_Board_Each_Time_A_New_Game_Is_Played()
        {
            _gameEngine.Play();
            _board.Verify(x => x.Reset(), Times.Exactly(3));
        }

        [Test]
        public void GameEngine_Starts_The_Game_By_Calling_The_Play_Game_Handler_With_The_Display_And_Board()
        {
            _gameEngine.Play();
            _playGameHandler.Verify(x => x.HandlePlayGameRequest(_display.Object, _board.Object), Times.Exactly(3));
        }

        [Test]
        public void GameEngine_Prompts_The_User_If_They_Would_Like_To_Play_Again()
        {
            _gameEngine.Play();
            _playGameHandler.Verify(x => x.HandlePlayGameRequest(_display.Object, _board.Object), Times.Exactly(3));
        }
    }
}
