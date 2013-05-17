namespace MinesweeperProject
{
    using System;
    using System.Linq;

    public class Minesweeper
    {
        public static void Main(string[] args)
        {
            ConsoleMinesweeperGame game = new ConsoleMinesweeperGame(2,2,0);

            game.Start();
        }
    }
}
