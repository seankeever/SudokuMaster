using SudokuMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Services
{
    public static class PrintingService
    {
        public static void PrintGrid(SudokuGrid grid, char emptyChar = 'X')
        {
            for (int row = 1; row <= 9; row++)
            {
                string currentLine = string.Empty;
                for (int column = 1; column <= 9; column++)
                {
                    currentLine += grid.GetSquareAt(row, column).Value.ToString();
                }
                currentLine = currentLine.Replace('0', emptyChar);
                Console.WriteLine(currentLine);
            }
        }
        public static void PrintSquareByID(SudokuGrid grid, int squareID)
        {
            foreach (SudokuSquare square in grid)
            {
                if (square.SquareID == squareID)
                {
                    PrintSquare(square);
                }
            }
        }

        public static void PrintSquare(SudokuSquare square)
        {
            Console.WriteLine("ID: " + square.SquareID.ToString());
            Console.WriteLine("Row: " + square.Row.ToString());
            Console.WriteLine("Column: " + square.Column.ToString());
            Console.WriteLine("Is Set: " + square.IsSet.ToString());
            Console.WriteLine("Canidate List: " + "\n");

            foreach (Canidate c in square.CanidateList)
                if (!c.IsCrossedOff)
                    Console.WriteLine(c.Value.ToString());
        }
    }
}
