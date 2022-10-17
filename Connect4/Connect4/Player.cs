using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Player
    {
        private string name;
        private bool won;

        public Player(string name)
        {
            this.name = name;
            won = false;
        }
        public string Name { get => name; set => name = value; }
        public bool Won { get => won; set => won = value; }



        //TakeTurn goes through to turn process of a player
        public void TakeTurn(Board board)
        {
            int column = 0;
            int placedAt = 0;
            Console.WriteLine($"It is {this.Name}'s turn, please insert a chip at position 0-6\n");
            board.PrintBoard();
            try
            {
                column = Int16.Parse(Console.ReadLine());
                if (column < 0||column > 6)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                    TakeTurn(board);
                }
            }
            catch
            {
                Console.WriteLine("Invalid input, please enter a valid number.");
                TakeTurn(board);
            }

            for(int row = 5; row >= 0; row--) 
            {
                if (board.Field[row, column] == "   ")
                {
                    board.Field[row, column] = " " + this.Name[0] + " ";
                    placedAt = row;
                    break;
                }
                if(row == 0)
                {
                    Console.WriteLine("Line seems to be full, please use a valid line.");
                    TakeTurn(board);
                }
            }
            CheckForWinner(board,column,placedAt);
            Console.Clear();
            if(!board.BoardHasSpace())
            {
                Console.WriteLine("Board is full, it's a tie! Reset board and start a new game? Press 'y' to restart.");
                if(Console.ReadLine().ToLower() == "y")
                {
                    board.ResetBoard();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
        //CheckForWinner checks for a winner horizontally, vertically and diagonal after each chip placement
        public void CheckForWinner(Board board, int x, int y)
        {
            if(x-3 >= 0 && y+3 <= 5) //Diagonal Top -> Bottom Left
            {
                if (board.Field[y + 1, x - 1] == board.Field[y, x] && 
                    board.Field[y + 2, x - 2] == board.Field[y, x] &&
                    board.Field[y + 3, x - 3] == board.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (x + 3 <= 6 && y - 3 >= 0) //Diagonal Bottom -> Top Right
            {
                if (board.Field[y - 1, x + 1] == board.Field[y, x] &&
                    board.Field[y - 2, x + 2] == board.Field[y, x] &&
                    board.Field[y - 3, x + 3] == board.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (x + 3 <= 6 && y + 3 <= 5) //Diagonal Top -> Bottom Right
            {
                if (board.Field[y + 1, x + 1] == board.Field[y, x] &&
                    board.Field[y + 2, x + 2] == board.Field[y, x] &&
                    board.Field[y + 3, x + 3] == board.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (x - 3 >= 0 && y - 3 >= 0) //Diagonal Bottom -> Top Left
            {
                if (board.Field[y - 1, x - 1] == board.Field[y, x] &&
                    board.Field[y - 2, x - 2] == board.Field[y, x] &&
                    board.Field[y - 3, x - 3] == board.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if(x-3 >= 0) //Horzontal Left -> Right
            {
                if (board.Field[y, x - 1] == board.Field[y, x] &&
                    board.Field[y, x - 2] == board.Field[y, x] &&
                    board.Field[y, x - 3] == board.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (x + 3 <= 6) //Horzontal Right -> Left
            {
                if (board.Field[y, x + 1] == board.Field[y, x] &&
                    board.Field[y, x + 2] == board.Field[y, x] &&
                    board.Field[y, x + 3] == board.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (y - 3 >= 0) //Vertical Bottom -> Top
            {
                if (board.Field[y - 1, x] == board.Field[y, x] &&
                    board.Field[y - 2, x] == board.Field[y, x] &&
                    board.Field[y - 3, x] == board.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (y + 3 <= 5) //Vertical Top -> Bottom
            {
                if (board.Field[y + 1, x] == board.Field[y, x] &&
                    board.Field[y + 2, x] == board.Field[y, x] &&
                    board.Field[y + 3, x] == board.Field[y, x])
                {
                    this.Won = true;
                }
            }
        }
    }
}