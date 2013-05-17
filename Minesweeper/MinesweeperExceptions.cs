namespace MinesweeperProject
{
    using System;
    using System.Linq;

    /// <summary>
    /// Exception class used for throwing exceptions if the grid cell is invalid.
    /// </summary>
    public class InvalidCellException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellException" /> class,
        /// with no parameters and message "Invalid cell!"
        /// </summary>
        public InvalidCellException()
            : base("Invalid cell!")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellException" /> class,
        /// with option for custom message!"
        /// </summary>
        /// <param name="message">custom message</param>
        public InvalidCellException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Exception class used for throwing exceptions in case of illegal 
    /// movement in the grid.
    /// </summary>
    public class IllegalMoveException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IllegalMoveException" /> class
        /// with no parameters and message "Illegal move!"
        /// </summary>
        public IllegalMoveException()
            : base("Illegal move!")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IllegalMoveException" /> class,
        /// with option for custom message!"
        /// </summary>
        /// <param name="message">custom message</param>
        public IllegalMoveException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Exception class used for throwing exceptions in case unknown 
    /// command entered by the user.
    /// </summary>
    public class CommandUnknownException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandUnknownException" /> class,
        /// with no parameters and message "Command unknown!"
        /// </summary>
        public CommandUnknownException()
            : base("Command unknown!")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandUnknownException" /> class,
        /// with option for custom message!"
        /// </summary>
        /// <param name="message">custom message</param>
        public CommandUnknownException(string message)
            : base(message)
        {
        }
    }
}