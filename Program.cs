using System;
using System.Linq;

namespace MinesweeperProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMinesweeperGame game = new ConsoleMinesweeperGame(5,10,15);

            game.Start();
        }
    }
}
