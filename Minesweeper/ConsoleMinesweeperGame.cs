namespace MinesweeperProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The class for the controls to the game
    /// </summary>
    internal class ConsoleMinesweeperGame : MinesweeperGame
    {
        /// <summary>
        /// The constructor for the class.
        /// </summary>
        /// <param name="rows">Takes the rows</param>
        /// <param name="columns">Takes the columns</param>
        /// <param name="minesCount">Number of the mines</param>
        public ConsoleMinesweeperGame(int rows, int columns, int minesCount)
            : base(rows, columns, minesCount)
        {
        }

        /// <summary>
        /// The control for the start game with the start game message
        /// </summary>
        public override void Start()
        {
            base.Start();
            string startMessage = "Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            Console.WriteLine(startMessage);
            Console.WriteLine(Grid.ToString());
            this.NextCommand();
        }

        /// <summary>
        /// Waits for the player to enter a row and a column and trims the input to take the parameters
        /// </summary>
        public void NextCommand() ////console -  output grid and message to request command
        {
            Console.Write("Enter row and column:");

            string commandLine = Console.ReadLine().ToUpper().Trim();

            List<string> commandList = commandLine.Split(' ').ToList();

            if (commandList.Count == 0)
            {
                this.NextCommand();
            }

            try
            {
                string firstCommand = commandList.ElementAt(0);
                switch (firstCommand)
                {
                    case "RESTART":
                        this.Start();
                        break;
                    case "TOP":
                        this.PrintScoreBoard();
                        this.NextCommand();
                        break;
                    case "EXIT":
                        this.Exit();
                        break;
                    default:
                        {
                            int row = 0;
                            int column = 0;
                            bool tryParse = false;

                            tryParse = int.TryParse(commandList.ElementAt(0), out row) || tryParse;
                            tryParse = int.TryParse(commandList.ElementAt(1), out column) && tryParse;

                            if (!tryParse || commandList.Count < 2)
                            {
                                throw new CommandUnknownException();
                            }

                            if (Grid.RevealCell(row, column) == '*')
                            {
                                Grid.MarkCell('-');
                                Grid.RevealMines();
                                Console.WriteLine(Grid.ToString());
                                Console.WriteLine(string.Format("Booooom! You were killed by a mine. You revealed {0} cells without mines.", this.Score));
                                Console.Write("Please enter your name for the top scoreboard: ");
                                string playerName = Console.ReadLine();
                                ScoreBoard.Add(new ScoreRecord(playerName, Score));
                                Console.WriteLine();
                                this.PrintScoreBoard();
                                this.Start();
                            }
                            else
                            {
                                Console.WriteLine(Grid.ToString());
                                this.Score++;
                                this.NextCommand();
                            }
                        }

                        break;
                }
            }
            catch (InvalidCellException)
            {
                Console.WriteLine("Illegal move!");
                this.NextCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.NextCommand();
            }
        }

        /// <summary>
        /// The command to exit the game
        /// </summary>
        public void Exit()
        {
            Console.WriteLine("Good bye!");
        }

        /// <summary>
        /// The method that build the scores with the name of the player
        /// </summary>
        public void PrintScoreBoard()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Scoreboard:");
            ScoreBoard.Sort();
            int i = 0;
            foreach (ScoreRecord scoreRecord in this.ScoreBoard)
            {
                i++;
                stringBuilder.AppendFormat("{0}. {1} --> {2} cells \n", i, scoreRecord.PlayerName, scoreRecord.Score);
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
