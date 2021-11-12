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
        private static bool wasNarrowedDownLastTime = false;
        public static bool PopulateSingledOutCanidates(ref SudokuGrid grid)
        {
            bool wasNarrowedDown = false;
            foreach (SudokuSquare square in grid)
            {
                if (square.IsSet == false)
                {
                    List<int> canidates = GetValidCanidates(square);
                    if (canidates.Count == 1)
                    {
                        grid.GetSquareAt(square.Row, square.Column).Value = canidates[0];
                        grid.GetSquareAt(square.Row, square.Column).IsSet = true;
                        wasNarrowedDown = true;
                    }

                }
            }
            wasNarrowedDownLastTime = wasNarrowedDown;
            return wasNarrowedDown;
        }

        private static List<int> GetValidCanidates(SudokuSquare square)
        {
            List<int> validCanidates = new List<int>();
            CanidateList list = square.CanidateList;

            foreach (Canidate c in list)
                if (!c.IsCrossedOff)
                    validCanidates.Add(c.Value);

            return validCanidates;
        }

        public static void NarrowDownCanidates(ref SudokuGrid grid)
        {
            for (int row = 1; row <= 9; row++)
            {
                List<SudokuSquare> currentRow = grid.GetRowAt(row);
                List<int> permanentValues = GetPermanentValues(currentRow);
                ScratchOutTakenValues(ref grid, currentRow, permanentValues);
            }

            for (int column = 1; column <= 9; column++)
            {
                List<SudokuSquare> currentColumn = grid.GetColumnAt(column);
                List<int> permanentValues = GetPermanentValues(currentColumn);
                ScratchOutTakenValues(ref grid, currentColumn, permanentValues);
            }

            for (int region = 1; region <= 9; region++)
            {
                List<SudokuSquare> currentRegion = grid.GetRegionAt(region);
                List<int> permanentValues = GetPermanentValues(currentRegion);
                ScratchOutTakenValues(ref grid, currentRegion, permanentValues);
            }
        }

        private static void ScratchOutTakenValues(ref SudokuGrid grid, List<SudokuSquare> focussSet, List<int> permanentValues)
        {
            foreach (SudokuSquare square in focussSet)
            {
                foreach (int permanentValue in permanentValues)
                    grid.GetSquareAt(square.Row, square.Column).CanidateList.GetCanidateByValue(permanentValue).IsCrossedOff = true;
            }
        }

        private static List<int> GetPermanentValues(List<SudokuSquare> focussSet)
        {
            List<int> permanentValues = new List<int>();
            foreach (SudokuSquare square in focussSet)
                if (square.Value != 0)
                    permanentValues.Add(square.Value);
            return permanentValues;
        }



        public static SudokuGrid InitializePuzzle(string puzzlePath, string puzzleName)
        {
            try
            {
                StreamReader st = new StreamReader(puzzlePath + puzzleName);
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
            catch(Exception ex)
            {
                Console.WriteLine("Error Initializing Puzzle" + "\n");
                Console.WriteLine("Message:" + ex.Message + "\n");
                Console.WriteLine("Inner Exception:" + ex.InnerException + "\n");
                Console.WriteLine("Stack Trace:" + ex.StackTrace);
            }
            return null;
        }















        internal static void TakeAGuess(ref SudokuGrid grid)
        {
            SudokuSquare squareWithLikelyCanidates = FindSquareWithLikelyCanidates(ref grid);
            CanidateList likelyCanidates = squareWithLikelyCanidates.CanidateList;
            grid.GetSquareAt(squareWithLikelyCanidates.Row, squareWithLikelyCanidates.Column).Value = likelyCanidates.GetAnyValidCandiate().Value;
        }

        private static SudokuSquare FindSquareWithLikelyCanidates(ref SudokuGrid grid)
        {
            //List<SudokuSquare> likeCanidates = new List<SudokuSquare>();
            //List<int> currentSquaresCanidates = GetValidCanidates(square);
            //List<int> likelyCanidates = new List<int>() { 0,0,0,0,0,0,0,0,0}; 
            int lowestNumberOfCanidates = 9;
            SudokuSquare squareWithLikelyCanidates = null;

            foreach (SudokuSquare square in grid)
                if (GetValidCanidates(square).Count <= lowestNumberOfCanidates)
                    squareWithLikelyCanidates = square;

            return squareWithLikelyCanidates;
        }
    }
}
