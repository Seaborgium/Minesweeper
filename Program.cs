namespace MinesweeperProject
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleMinesweeperGame game = new ConsoleMinesweeperGame(5, 10, 15);

            game.Start();
        }
    }
}
