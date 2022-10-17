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
        const int numRows = 6;
        const int numColumns = 7;

        private string[,] field = new string[numRows, numColumns];

        public string[,] Field { get => field; set => field = value; }

        public Board()
        {

        }
        //Resets the board preparing it for a new game
        public void ResetBoard()
        {
            this.field = new string[numRows, numColumns];
            this.FillField();
            Console.WriteLine("Board reset.");
        }
        //Checks if the board is full
        public bool BoardHasSpace()
        {
            bool hasSpace = false;
            for(int i = 0; i< numColumns; i++)
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
            for(int i = 0; i < numRows; i++)
            {
                for(int k = 0; k < numColumns; k++)
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
            for(int i = 0; i < numRows; i++)
            {
                for(int k = 0; k < numColumns; k++)
                {
                    this.field[i, k] = "   ";
                }
            }
        }
    }
}
