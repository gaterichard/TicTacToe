using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.PlayGameHandlers;

namespace TicTacToe
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameDisplay>().To<ConsoleGameDisplay>();
            Bind<IMoveStrategy>().To<RandomMoveStrategy>();
            Bind<IBoard>().To<Board>();

            Bind<PlayGameHandler>().ToMethod(x =>
            {
                var playGameWelcomeHandler = new PlayGameWelcomeHandler();
                var playGameMoveHandler = new PlayGameMoveHandler(new RandomMoveStrategy());
                playGameWelcomeHandler.SetSuccessor(playGameMoveHandler);
                playGameMoveHandler.SetSuccessor(new PlayGameResultHandler());
                return playGameWelcomeHandler;
            });
        }
    }
}
