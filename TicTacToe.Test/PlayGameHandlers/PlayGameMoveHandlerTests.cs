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
    public class PlayGameMoveHandlerTests
    {
        private PlayGameMoveHandler _playGameMoveHandler;
        private Mock<IGameDisplay> _display;
        private Mock<IBoard> _fiveTurnBoard;
        private Mock<PlayGameHandler> _successor;
        private Mock<IMoveStrategy> _moveStrategy;

        [SetUp]
        public void Setup()
        {
            _display = new Mock<IGameDisplay>();
            _fiveTurnBoard = new Mock<IBoard>();
            _moveStrategy = new Mock<IMoveStrategy>();

            _fiveTurnBoard.SetupSequence<IBoard, bool>(x => x.IsInPlay()).Returns(true)
                                                      .Returns(true)
                                                      .Returns(true)
                                                      .Returns(true)
                                                      .Returns(false);
                                                      
            _successor = new Mock<PlayGameHandler>();
            _playGameMoveHandler = new PlayGameMoveHandler(_moveStrategy.Object);
            _playGameMoveHandler.SetSuccessor(_successor.Object);
        }

        [Test]
        public void Displays_A_Turn_Message_For_Each_Turn()
        {
            _playGameMoveHandler.HandlePlayGameRequest(_display.Object, _fiveTurnBoard.Object);
            _display.Verify(x => x.TurnMessage(1), Times.Once());
            _display.Verify(x => x.TurnMessage(2), Times.Once());
            _display.Verify(x => x.TurnMessage(3), Times.Once());
            _display.Verify(x => x.TurnMessage(4), Times.Once());
            _display.Verify(x => x.TurnMessage(5), Times.Once());
        }

        [Test]
        public void Makes_A_Move_For_Each_Player()
        {
            _playGameMoveHandler.HandlePlayGameRequest(_display.Object, _fiveTurnBoard.Object);
            _moveStrategy.Verify(x => x.Move('X', _fiveTurnBoard.Object), Times.Exactly(3));
            _moveStrategy.Verify(x => x.Move('O', _fiveTurnBoard.Object), Times.Exactly(2));
        }

        public void Renders_The_Board_On_Each_Turn()
        {
            _playGameMoveHandler.HandlePlayGameRequest(_display.Object, _fiveTurnBoard.Object);
            _display.Verify(x => x.DrawBoard(_fiveTurnBoard.Object), Times.Exactly(5));
        }

        public void Checks_If_The_Board_Is_In_Play_After_Every_Turn()
        {
            _playGameMoveHandler.HandlePlayGameRequest(_display.Object, _fiveTurnBoard.Object);
            _fiveTurnBoard.Verify(x => x.IsInPlay(), Times.Exactly(5));
        }

        [Test]
        public void The_Next_Handler_Is_Called_With_The_Display_And_Board()
        {
            _playGameMoveHandler.HandlePlayGameRequest(_display.Object, _fiveTurnBoard.Object);
            _successor.Verify(x => x.HandlePlayGameRequest(_display.Object, _fiveTurnBoard.Object), Times.Once());
        }
    }
}
