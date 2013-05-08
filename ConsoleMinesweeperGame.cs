namespace MinesweeperProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class ConsoleMinesweeperGame : MinesweeperGame
    {
        private string commandLine;
        private bool playGame = true;
        private StringBuilder renderBuffer = new StringBuilder();
        public ConsoleMinesweeperGame(int rows, int columns, int minesCount)
            : base(rows, columns, minesCount)
        {
        }

        public override void Start()
        {
            base.Start();
            string greetingMessage = "Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            Console.WriteLine(greetingMessage);
            Console.WriteLine(Grid.ToString());

            while (playGame)
            {
                this.ReadCommand();
                this.ExecuteCommand();
                this.Render();
            }
        }

        public void ReadCommand() ////console -  output grid and message to request command
        {
            Console.Write("Enter row and column:");
            this.commandLine = Console.ReadLine().ToUpper().Trim();
        }

        private void ExecuteCommand()
        {
            string coordinatesPattern = @"\d+\s\d+";
            bool isCoordinate = Regex.IsMatch(this.commandLine, coordinatesPattern);

            if (isCoordinate)
            {
                ExecuteCoordCommand();
            }
            else
            {
                ExecuteMenuCommand();
            }
        }


        private void ExecuteCoordCommand()
        {
            int row = 0;
            int column = 0;
            bool tryParse;
            string[] coordinates = commandLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            tryParse = int.TryParse(coordinates[0], out row);
            tryParse = int.TryParse(coordinates[1], out column) && tryParse;

            if (!tryParse)
            {
                throw new CommandUnknownException();
            }

            if (Grid.RevealCell(row, column) == '*')
            {
                Grid.MarkCell('-');
                Grid.RevealMines();
                this.renderBuffer.AppendLine(Grid.ToString());
                this.renderBuffer.AppendLine(string.Format("Booooom! You were killed by a mine. You revealed {0} cells without mines.", this.Score));
                this.renderBuffer.AppendLine("Please enter your name for the top scoreboard: ");

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
                this.ReadCommand();
            }
        }


        private void ExecuteMenuCommand()
        {
            //string[] command = commandLine.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            //if (this.commandList.Count < 2)
            //{
            //    throw new CommandUnknownException();
            //}
            //if (commandList.Count == 0)
            //{
            //    this.ReadCommand();
            //}

            try
            {
                switch (this.commandLine)
                {
                    case "RESTART":
                        this.Start();
                        break;
                    case "TOP":
                        this.PrintScoreBoard();
                        break;
                    case "EXIT":
                        Console.WriteLine("Good bye!");
                        break;
                    case "CHEAT":
                        {
                            Grid.RevealMines();
                            this.renderBuffer.AppendLine(Grid.ToString());
                        }

                        break;
                }
            }
            catch (InvalidCellException)
            {
                Console.WriteLine("Illegal move!");
                this.ReadCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.ReadCommand();
            }
        }

        public void PrintScoreBoard()
        {
            this.renderBuffer.AppendLine("Scoreboard:");
            ScoreBoard.Sort();
            int i = 0;
            foreach (ScoreRecord scoreRecord in this.ScoreBoard)
            {
                i++;
                this.renderBuffer.AppendFormat("{0}. {1} --> {2} cells \n", i, scoreRecord.PlayerName, scoreRecord.Score);
            }
        }

        private void Render()
        {
            Console.WriteLine(renderBuffer);
            renderBuffer.Clear();
        }
    }
}
