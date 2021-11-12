using SudokuMaster.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Services
{
    public static class ImportExportService
    {
        public static void ExportCompletedPuzzleSolution(SudokuGrid grid, string originPath)
        {
            string allText = string.Empty;
            for (int row = 1; row <= 9; row++)
            {
                string currentLine = string.Empty;
                for (int column = 1; column <= 9; column++)
                {
                    currentLine += grid.GetSquareAt(row, column).Value.ToString();
                }
                if(row<9)
                    allText += currentLine + "\n";
                else
                    allText += currentLine;
            }
            string fullPath = originPath.Substring(0, originPath.Length - 3) + "sln.txt";
            File.WriteAllText(fullPath,allText);
        }
    }
}
