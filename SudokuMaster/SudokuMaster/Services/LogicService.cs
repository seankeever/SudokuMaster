using SudokuMaster.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Services
{
    public static class LogicService
    {
        public static SudokuGrid InitializePuzzle(string puzzlePath)
        {
            StreamReader st = new StreamReader(puzzlePath);
            List<string> rows = new List<string>();
            rows.Add("Blank Row to fill up 0'th row index to improve understandability");
            while (!st.EndOfStream)
                rows.Add("_" + st.ReadLine());

            SudokuGrid grid = new SudokuGrid();

            for (int row = 1; row <= 9; row++)
            {
                for (int column = 1; column <= 9; column++)
                {
                    string currentInputValue = rows[row][column].ToString();
                    if (currentInputValue != "X")
                    {
                        int permanentValue = int.Parse(currentInputValue.ToString());
                        SudokuSquare currentSquare = grid.GetSquareAt(row, column);
                        currentSquare.Value = permanentValue;
                        currentSquare.IsSet = true;
                    }
                }
            }

            return grid;
        }

        public static bool FastSolve(SudokuGrid grid)
        {
            // Look for square with fewest possible values
            int bestIdx = -1, bestCount = 10;
            for (int i = 0; i < 81; i++)
                if (!grid.Squares[i].IsSet)
                {
                    List<int> pv = grid.PossibleValues(i);
                    if (pv.Count == 0) return false;
                    if (pv.Count < bestCount)
                    {
                        bestIdx = i;
                        bestCount = pv.Count;
                    }
                }

            // Try each possible value for that square
            if (bestIdx >= 0)
            {
                foreach (int i in grid.PossibleValues(bestIdx))
                {
                    grid.Squares[bestIdx].IsSet = true;
                    grid.Squares[bestIdx].Value = i;
                    if (FastSolve(grid)) return true;
                }
                grid.Squares[bestIdx].IsSet = false; // backtrack
                return false; // no solution, tell outer call(s) to try different values
            }
            return true; // no unset squares, so we solved it
        }
    }
}
