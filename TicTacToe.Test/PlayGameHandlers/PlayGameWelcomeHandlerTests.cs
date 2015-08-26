using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.PlayGameHandlers;

namespace TicTacToe.Test.PlayGameHandlers
{
    [TestFixture]
    public class PlayGameWelcomeHandlerTests
    {
        private PlayGameWelcomeHandler _playGameWelcomeHandler;
        private Mock<IGameDisplay> _display;
        private Mock<IBoard> _board;
        private Mock<PlayGameHandler> _successor;

        [SetUp]
        public void Setup()
        {
            _display = new Mock<IGameDisplay>();
            _board = new Mock<IBoard>();
            _successor = new Mock<PlayGameHandler>();
            _playGameWelcomeHandler = new PlayGameWelcomeHandler();
            _playGameWelcomeHandler.SetSuccessor(_successor.Object);
        }

        [Test]
        public void The_User_Is_Presented_A_Welcome_Message()
        {
            _playGameWelcomeHandler.HandlePlayGameRequest(_display.Object, _board.Object);
            _display.Verify(x => x.WelcomeMessage(), Times.Once());
        }

        [Test]
        public void The_Next_Handler_Is_Called_With_The_Display_And_Board()
        {
            _playGameWelcomeHandler.HandlePlayGameRequest(_display.Object, _board.Object);
            _successor.Verify(x => x.HandlePlayGameRequest(_display.Object, _board.Object), Times.Once());
        }
    }
}
