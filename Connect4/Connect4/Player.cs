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
        public void TakeTurn(Board b)
        {
            int i = 0;
            int placedAt = 0;
            Console.WriteLine($"It is {this.Name}'s turn, please insert a chip at position 0-6\n");
            b.PrintBoard();
            try
            {
                i = Int16.Parse(Console.ReadLine());
                if (i < 0||i > 6)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                    TakeTurn(b);
                }
            }
            catch
            {
                Console.WriteLine("Invalid input, please enter a valid number.");
                TakeTurn(b);
            }

            for(int k = 5; k >= 0; k--) 
            {
                if (b.Field[k, i] == "   ")
                {
                    b.Field[k, i] = " " + this.Name[0] + " ";
                    placedAt = k;
                    break;
                }
                if(k == 0)
                {
                    Console.WriteLine("Line seems to be full, please use a valid line.");
                    TakeTurn(b);
                }
            }
            CheckForWinner(b,i,placedAt);
            Console.Clear();
            if(b.CheckBoard() == false)
            {
                Console.WriteLine("Board is full, it's a tie! Reset board and start a new game? Press 'y' to restart.");
                if(Console.ReadLine().ToLower() == "y")
                {
                    b.ResetBoard();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
        //CheckForWinner checks for a winner horizontally, vertically and diagonal after each chip placement
        public void CheckForWinner(Board b, int x, int y)
        {
            if(x-3 >= 0 && y+3 <= 5) //Diagonal Top -> Bottom Left
            {
                if (b.Field[y + 1, x - 1] == b.Field[y, x] && 
                    b.Field[y + 2, x - 2] == b.Field[y, x] &&
                    b.Field[y + 3, x - 3] == b.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (x + 3 <= 6 && y - 3 >= 0) //Diagonal Bottom -> Top Right
            {
                if (b.Field[y - 1, x + 1] == b.Field[y, x] &&
                    b.Field[y - 2, x + 2] == b.Field[y, x] &&
                    b.Field[y - 3, x + 3] == b.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (x + 3 <= 6 && y + 3 <= 5) //Diagonal Top -> Bottom Right
            {
                if (b.Field[y + 1, x + 1] == b.Field[y, x] &&
                    b.Field[y + 2, x + 2] == b.Field[y, x] &&
                    b.Field[y + 3, x + 3] == b.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (x - 3 >= 0 && y - 3 >= 0) //Diagonal Bottom -> Top Left
            {
                if (b.Field[y - 1, x - 1] == b.Field[y, x] &&
                    b.Field[y - 2, x - 2] == b.Field[y, x] &&
                    b.Field[y - 3, x - 3] == b.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if(x-3 >= 0) //Horzontal Left -> Right
            {
                if (b.Field[y, x - 1] == b.Field[y, x] &&
                    b.Field[y, x - 2] == b.Field[y, x] &&
                    b.Field[y, x - 3] == b.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (x + 3 <= 6) //Horzontal Right -> Left
            {
                if (b.Field[y, x + 1] == b.Field[y, x] &&
                    b.Field[y, x + 2] == b.Field[y, x] &&
                    b.Field[y, x + 3] == b.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (y - 3 >= 0) //Vertical Bottom -> Top
            {
                if (b.Field[y - 1, x] == b.Field[y, x] &&
                    b.Field[y - 2, x] == b.Field[y, x] &&
                    b.Field[y - 3, x] == b.Field[y, x])
                {
                    this.Won = true;
                }
            }
            if (y + 3 <= 5) //Vertical Top -> Bottom
            {
                if (b.Field[y + 1, x] == b.Field[y, x] &&
                    b.Field[y + 2, x] == b.Field[y, x] &&
                    b.Field[y + 3, x] == b.Field[y, x])
                {
                    this.Won = true;
                }
            }
        }
    }
}