using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Board
    {
        private string[,] field = new string[6,7]; //6 Rows 7 Columns

        public string[,] Field { get => field; set => field = value; }

        public Board()
        {

        }
        //Resets the board preparing it for a new game
        public void ResetBoard()
        {
            this.field = new string[6, 7];
            this.FillField();
            Console.WriteLine("Board reset.");
        }
        //Checks if the board is full
        public bool CheckBoard()
        {
            bool hasSpace = false;
            for(int i = 0; i<7; i++)
            {
                if (this.field[0,i] == "   ")
                {
                    hasSpace = true;
                }
            }
            return hasSpace;
        }
        //Prints the Board to the console
        public void PrintBoard()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int k = 0; k < 7; k++)
                {
                    Console.Write(this.field[i, k]);
                }
                Console.Write(System.Environment.NewLine);
            }
            Console.Write(System.Environment.NewLine);
        }
        //Fills the Board with spaces, I chose spaces just so it looks prettier
        public void FillField()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int k = 0; k < 7; k++)
                {
                    this.field[i, k] = "   ";
                }
            }
        }
    }
}
