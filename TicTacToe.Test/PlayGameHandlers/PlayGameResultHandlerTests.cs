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
    public class PlayGameResultHandlerTests
    {
        private PlayGameResultHandler _playGameResultHandler;
        private Mock<IGameDisplay> _display;
        private Mock<IBoard> _board;
        private Mock<PlayGameHandler> _successor;

        [SetUp]
        public void Setup()
        {
            _display = new Mock<IGameDisplay>();
            _board = new Mock<IBoard>();
            _successor = new Mock<PlayGameHandler>();
            _playGameResultHandler = new PlayGameResultHandler();
            _playGameResultHandler.SetSuccessor(_successor.Object);
        }

        [Test]
        public void If_The_Game_Is_Won_A_Win_Message_Is_Displayed_Informing_The_Players_Who_Won()
        {
            _board.Setup(x => x.GetResult()).Returns('X');
            _playGameResultHandler.HandlePlayGameRequest(_display.Object, _board.Object);
            _display.Verify(x => x.WinMessage('X'), Times.Once());
            _display.Verify(x => x.DrawMessage(), Times.Never());
        }

        [Test]
        public void If_The_Game_Is_Tied_A_Draw_Message_Is_Displayed()
        {
            _board.Setup(x => x.GetResult()).Returns((char?)null);
            _playGameResultHandler.HandlePlayGameRequest(_display.Object, _board.Object);
            _display.Verify(x => x.DrawMessage(), Times.Once());
            _display.Verify(x => x.WinMessage(It.IsAny<char>()), Times.Never());
        }

        [Test]
        public void The_Next_Handler_Is_Called_With_The_Display_And_Board()
        {
            _playGameResultHandler.HandlePlayGameRequest(_display.Object, _board.Object);
            _successor.Verify(x => x.HandlePlayGameRequest(_display.Object, _board.Object), Times.Once());
        }
    }
}
