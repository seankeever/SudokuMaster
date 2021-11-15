using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Models
{
    public class SudokuGrid : IEnumerable
    {
        public SudokuGrid()
        {
            InitializeSquares();
            this.IsSolved = false;
        }

        private void InitializeSquares()
        {
            for (int i = 0; i < 81; i++)
            {
                SudokuSquare square = new SudokuSquare();
                square.Row = i / 9 + 1;
                square.Column = i % 9 + 1;
                square.Region = i / 27 * 3 + i % 9 / 3 + 1;
                Squares.Add(square);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (SudokuSquare square in Squares)
            {
                if (square == null)
                    break;
                yield return square;
            }
        }

        public List<SudokuSquare> Squares = new List<SudokuSquare>();

        public bool IsSolved { get; set; }





        public SudokuSquare GetSquareAt(int row, int column)
        {
            SudokuSquare square = Squares[(row - 1) * 9 + column - 1];
            return square;
        }

        public List<SudokuSquare> GetRowAt(int rowNumber)
        {
            List<SudokuSquare> row = new List<SudokuSquare>();

            foreach (SudokuSquare square in Squares)
                if (square.Row == rowNumber)
                    row.Add(square);

            return row;
        }

        public List<SudokuSquare> GetColumnAt(int columnNumber)
        {
            List<SudokuSquare> column = new List<SudokuSquare>();

            foreach (SudokuSquare square in Squares)
                if (square.Column == columnNumber)
                    column.Add(square);

            return column;
        }

        public List<SudokuSquare> GetRegionAt(int regionNumber)
        {
            List<SudokuSquare> region = new List<SudokuSquare>();

            foreach (SudokuSquare square in Squares)
                if (square.Region == regionNumber)
                    region.Add(square);

            return region;
        }

        // Only eliminate conflicts in row/column/region.  We can do more clever things to speed it up, but this will probably be fast enough
        public List<int> PossibleValues(int idx)
        {
            List<int> pv = new List<int>();
            if (Squares[idx].IsSet)
            {
                pv.Add(Squares[idx].Value);
                return pv; // just return the set value if one is set already
            }
            if (nbr == null)
            { // build static array of indices of neighboring squares (same row, column, or region), once per SudokuGrid instance
                nbr = new List<int>[81];
                for (int i = 0; i < 81; i++) nbr[i] = new List<int>();
                for (int i = 0; i < 81; i++)
                    for (int j = i + 1; j < 81; j++)
                        if (Squares[i].Row == Squares[j].Row || Squares[i].Column == Squares[j].Column || Squares[i].Region == Squares[j].Region)
                        {
                            nbr[i].Add(j);
                            nbr[j].Add(i);
                        }
            }
            bool[] conflict = new bool[10];
            foreach (int i in nbr[idx])
                if (Squares[i].IsSet) conflict[Squares[i].Value] = true;
            for (int i = 1; i < 10; i++)
                if (!conflict[i]) pv.Add(i);
            return pv;
        }

        private List<int>[] nbr = null;
    }
}
