using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperProject
{
    // "Tova e test commit" - Hristo
	// kofti kod stana, ama sym dovolen, ima kakvo da se popravia

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMinesweeperGame game = new ConsoleMinesweeperGame(5,10,15);

            game.Start();
        }
    }
}
