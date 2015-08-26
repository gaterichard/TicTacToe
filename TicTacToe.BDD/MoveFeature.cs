using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TicTacToe.BDD
{
    [Binding]
    public sealed class MoveFeature
    {
        private Board _board = new Board();

        [Given(@"the board contains an '(.*)' in cell (.*)")]
        [When(@"player '(.*)' makes a move into cell (.*)")]
        public void GivenTheBoardContainsAnInCell(string player, int cell)
        {
            try
            {
                _board.SetSpace(player.ToCharArray()[0], cell);
            }
            catch (IllegalMoveException e)
            {
                ScenarioContext.Current.Add("Exception_WhenMoving", e);
            }
        }


        [Then(@"player '(.*)' should win the game\.")]
        public void ThenPlayerShouldWinTheGame_(string player)
        {
            Assert.AreEqual(player.ToCharArray()[0], _board.GetResult());
        }

        [Then(@"the move is invalid")]
        public void ThenTheMoveIsInvalid()
        {
            var exception = ScenarioContext.Current["Exception_WhenMoving"];
            Assert.NotNull(exception);
        }


    }
}
