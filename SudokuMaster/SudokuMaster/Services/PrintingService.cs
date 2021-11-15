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
    }
}
