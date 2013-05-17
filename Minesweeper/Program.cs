namespace MinesweeperProject
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleMinesweeperGame game = new ConsoleMinesweeperGame(9, 9, 10);

            game.Start();
        }
    }
}
