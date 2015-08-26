using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            GameEngine gameEngine = kernel.Get<GameEngine>();

            gameEngine.Play();
        }
    }
}
