using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game : IGame
    {
        private readonly IStringGetterPutter _stringGetterPutter;
        //Default Constructor
        public Game() : this(new ConsoleWrapper(), new Board(new ConsoleWrapper())) { }

        //Test Contructor
        public Game(IStringGetterPutter stringGetterPutter, Board board)
        {
            _stringGetterPutter = stringGetterPutter;
            _board = board;
        }
        private Player activePlayer;
    
        private List<Player> players = new List<Player>();

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        private int indexOfCurrentPlayer = 0;
        private Board _board;

        public void RunGame()
        {

            activePlayer = players[indexOfCurrentPlayer];

            do
            {
                _stringGetterPutter.PutString("Here is the board:");
                _board.PrintBoard();

                TakeTurn(activePlayer);
                //select the other player
                indexOfCurrentPlayer = (indexOfCurrentPlayer == 0) ? 1 : 0;
                activePlayer = players[indexOfCurrentPlayer];

                //Added this slight delay for user experience.  Without it it's harder to notice the board repaint
                //try commenting it out and check out the difference.  Which do you prefer?
                System.Threading.Thread.Sleep(300);

                _stringGetterPutter.Clear();
            }
            while (!GameOver());
        }

        private bool GameOver()
        {
            int winValue = players[(indexOfCurrentPlayer == 0) ? 1 : 0].Token * 3;
            return _board.IsGameOver(winValue);
        }


        private void TakeTurn(Player activePlayer)
        {          
            _board.SetValue(activePlayer);
        }

    }

    public class Board
    {
        IStringGetterPutter _stringGetterPutter;
        private char[,] board = new char[3, 3];

        public Board(IStringGetterPutter stringGetterPutter)
        {
            _stringGetterPutter = stringGetterPutter;
        }
       public void PrintBoardMap()
        {
            int position = 1; //1-based board map (done for user experience)
            _stringGetterPutter.PutString(Environment.NewLine);
            for (int row = 0; row <= board.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= board.GetUpperBound(1); column++)
                {
                    _stringGetterPutter.PutString(position++.ToString());
                    if (column < board.GetUpperBound(1))
                    {
                        _stringGetterPutter.PutString(" - ");
                    }
                }
                _stringGetterPutter.PutString(Environment.NewLine);
            }
        }

        public void PrintBoard()
        {
            _stringGetterPutter.PutString(Environment.NewLine);
            for (int row = 0; row <= board.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= board.GetUpperBound(1); column++)
                {
                    _stringGetterPutter.PutString(board[row, column].ToString());

                    //only print the dashes for the inner columns
                    if (column < board.GetUpperBound(1))
                    {
                        _stringGetterPutter.PutString(" - ");
                    }
                    {
                        {                                                                                                                                                                                                                                                                                                                                                                 /*Congrats!  You found the easter egg!  Weren't those useless curly brackets annoying? Plus one was missing.... way out here on column 500+*/                                                         }
                    }
                }
                _stringGetterPutter.PutString(Environment.NewLine);
            }
        }

        public bool IsGameOver(int winValue)
        {
            //Check Colum win
            if (board[0, 0] != 0 &&
                (board[0, 0] +
                board[1, 0] +
                board[2, 0]) == winValue)
            {
                return true;
            }

            if (board[0, 1] != 0 &&
                (board[0, 1] +
                board[1, 1] +
                board[2, 1]) == winValue)
            {
                return true;
            }

            if (board[0, 2] != 0 &&
                (board[0, 2] +
                board[1, 2] +
                board[2, 2]) == winValue)
            {
                return true;
            }

            //Check Row Win
            if (board[0, 0] != 0 &&
                (board[0, 0] +
                board[0, 1] +
                board[0, 2]) == winValue)
            {
                return true;
            }

            if (board[1, 0] != 0 &&
                (board[1, 0] +
                board[1, 1] +
                board[1, 2]) == winValue)
            {
                return true;
            }

            if (board[2, 0] != 0 &&
                (board[2, 0] +
                board[2, 1] +
                board[2, 2]) == winValue)
            {
                return true;
            }

            // Check Cross win
            if (board[0, 0] != 0 &&
                (board[0, 0] +
                board[1, 1] +
                board[2, 2]) == winValue)
            {
                return true;
            }

            if (board[2, 2] != 0 &&
                (board[2, 2] +
                board[1, 1] +
                board[2, 0]) == winValue)
            {
                return true;
            }

            //Check for stale mate
            var isStalemate = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        isStalemate = false;
                        break;
                    }

                }
            }
            return isStalemate;
        }

        public void SetValue( Player activePlayer)
        {
            int[] position = PiecePlacement(activePlayer);
            board[position[0], position[1]] = activePlayer.Token;
        }


        private int[] PiecePlacement(Player activePlayer)
        {
            //you need to be using the .NET framework 4.6 for this line to work (C# 6)
            _stringGetterPutter.PutString(Environment.NewLine);
            _stringGetterPutter.PutString(activePlayer.Greet());
            _stringGetterPutter.PutString(Environment.NewLine);

            _stringGetterPutter.PutString($"{activePlayer.Name}, it's your turn:");
            _stringGetterPutter.PutString("Make your move by entering the number of the sqaure you'd like to take:");
            PrintBoardMap();
            _stringGetterPutter.PutString("Enter the number: ");

            //todo: Prevent returning a location that's already been used

            return ConvertToArrayLocation(_stringGetterPutter.GetInput());
        }

        public int[] ConvertToArrayLocation(string boardPosition)
        {
            int position; 
            Int32.TryParse(boardPosition, out position);
            if (position <= 0 || position > 9) return null;
            position--; //reduce position to account for 1-based board map (done for user experience)
            int row = position / 3;
            int column = position % 3;
            return new int[] { row, column }; //inline array initialization
        }
    }
}
