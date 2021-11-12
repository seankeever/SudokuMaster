using SudokuMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Services
{
    public static class ValidationService
    {
        public static bool CheckIfSolved(ref SudokuGrid grid)
        {
            for (int i = 1; i <= 9; i++)
            {
                if (!ValidateSet(grid.GetRowAt(i)))
                    return false;

                if (!ValidateSet(grid.GetColumnAt(i)))
                    return false;

                if (!ValidateSet(grid.GetRegionAt(i)))
                    return false;
            }

            grid.IsSolved = true;
            return true;
        }

        private static bool ValidateSet(List<SudokuSquare> focussSet)
        {
            List<int> values = new List<int>();

            foreach (SudokuSquare square in focussSet)
                if (square.Value != 0)
                    values.Add(square.Value);

            if (values.Count != 9)
                return false;

            for (int i = 1; i <= 9; i++)
                if (!values.Contains(i))
                    return false;

            return true;
        }
    }
}
