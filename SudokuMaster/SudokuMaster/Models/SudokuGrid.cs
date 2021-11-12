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
            for(int i=1;i<=81;i++)
            {
                SudokuSquare square = new SudokuSquare();
                square.SquareID = i;

                switch(i)
                {
                    //---------------------- Row 1 ----------------------
                    case 1:
                        square.Row = 1;
                        square.Column = 1;
                        square.Region = 1;
                        break;
                    case 2:
                        square.Row = 1;
                        square.Column = 2;
                        square.Region = 1;
                        break;
                    case 3:
                        square.Row = 1;
                        square.Column = 3;
                        square.Region = 1;
                        break;
                    case 4:
                        square.Row = 1;
                        square.Column = 4;
                        square.Region = 2;
                        break;
                    case 5:
                        square.Row = 1;
                        square.Column = 5;
                        square.Region = 2;
                        break;
                    case 6:
                        square.Row = 1;
                        square.Column = 6;
                        square.Region = 2;
                        break;
                    case 7:
                        square.Row = 1;
                        square.Column = 7;
                        square.Region = 3;
                        break;
                    case 8:
                        square.Row = 1;
                        square.Column = 8;
                        square.Region = 3;
                        break;
                    case 9:
                        square.Row = 1;
                        square.Column = 9;
                        square.Region = 3;
                        break;

                    //---------------------- Row 2 ----------------------
                    case 10:
                        square.Row = 2;
                        square.Column = 1;
                        square.Region = 1;
                        break;
                    case 11:
                        square.Row = 2;
                        square.Column = 2;
                        square.Region = 1;
                        break;
                    case 12:
                        square.Row = 2;
                        square.Column = 3;
                        square.Region = 1;
                        break;
                    case 13:
                        square.Row = 2;
                        square.Column = 4;
                        square.Region = 2;
                        break;
                    case 14:
                        square.Row = 2;
                        square.Column = 5;
                        square.Region = 2;
                        break;
                    case 15:
                        square.Row = 2;
                        square.Column = 6;
                        square.Region = 2;
                        break;
                    case 16:
                        square.Row = 2;
                        square.Column = 7;
                        square.Region = 3;
                        break;
                    case 17:
                        square.Row = 2;
                        square.Column = 8;
                        square.Region = 3;
                        break;
                    case 18:
                        square.Row = 2;
                        square.Column = 9;
                        square.Region = 3;
                        break;
                    //---------------------- Row 3 ----------------------
                    case 19:
                        square.Row = 3;
                        square.Column = 1;
                        square.Region = 1;
                        break;
                    case 20:
                        square.Row = 3;
                        square.Column = 2;
                        square.Region = 1;
                        break;
                    case 21:
                        square.Row = 3;
                        square.Column = 3;
                        square.Region = 1;
                        break;
                    case 22:
                        square.Row = 3;
                        square.Column = 4;
                        square.Region = 2;
                        break;
                    case 23:
                        square.Row = 3;
                        square.Column = 5;
                        square.Region = 2;
                        break;
                    case 24:
                        square.Row = 3;
                        square.Column = 6;
                        square.Region = 2;
                        break;
                    case 25:
                        square.Row = 3;
                        square.Column = 7;
                        square.Region = 3;
                        break;
                    case 26:
                        square.Row = 3;
                        square.Column = 8;
                        square.Region = 3;
                        break;
                    case 27:
                        square.Row = 3;
                        square.Column = 9;
                        square.Region = 3;
                        break;

                    //---------------------- Row 4 ----------------------
                    case 28:
                        square.Row = 4;
                        square.Column = 1;
                        square.Region = 4;
                        break;
                    case 29:
                        square.Row = 4;
                        square.Column = 2;
                        square.Region = 4;
                        break;
                    case 30:
                        square.Row = 4;
                        square.Column = 3;
                        square.Region = 4;
                        break;
                    case 31:
                        square.Row = 4;
                        square.Column = 4;
                        square.Region = 5;
                        break;
                    case 32:
                        square.Row = 4;
                        square.Column = 5;
                        square.Region = 5;
                        break;
                    case 33:
                        square.Row = 4;
                        square.Column = 6;
                        square.Region = 5;
                        break;
                    case 34:
                        square.Row = 4;
                        square.Column = 7;
                        square.Region = 6;
                        break;
                    case 35:
                        square.Row = 4;
                        square.Column = 8;
                        square.Region = 6;
                        break;
                    case 36:
                        square.Row = 4;
                        square.Column = 9;
                        square.Region = 6;
                        break;


                    //---------------------- Row 5 ----------------------
                    case 37:
                        square.Row = 5;
                        square.Column = 1;
                        square.Region = 4;
                        break;
                    case 38:
                        square.Row = 5;
                        square.Column = 2;
                        square.Region = 4;
                        break;
                    case 39:
                        square.Row = 5;
                        square.Column = 3;
                        square.Region = 4;
                        break;
                    case 40:
                        square.Row = 5;
                        square.Column = 4;
                        square.Region = 5;
                        break;
                    case 41:
                        square.Row = 5;
                        square.Column = 5;
                        square.Region = 5;
                        break;
                    case 42:
                        square.Row = 5;
                        square.Column = 6;
                        square.Region = 5;
                        break;
                    case 43:
                        square.Row = 5;
                        square.Column = 7;
                        square.Region = 6;
                        break;
                    case 44:
                        square.Row = 5;
                        square.Column = 8;
                        square.Region = 6;
                        break;
                    case 45:
                        square.Row = 5;
                        square.Column = 9;
                        square.Region = 6;
                        break;


                    //---------------------- Row 6 ----------------------
                    case 46:
                        square.Row = 6;
                        square.Column = 1;
                        square.Region = 4;
                        break;
                    case 47:
                        square.Row = 6;
                        square.Column = 2;
                        square.Region = 4;
                        break;
                    case 48:
                        square.Row = 6;
                        square.Column = 3;
                        square.Region = 4;
                        break;
                    case 49:
                        square.Row = 6;
                        square.Column = 4;
                        square.Region = 5;
                        break;
                    case 50:
                        square.Row = 6;
                        square.Column = 5;
                        square.Region = 5;
                        break;
                    case 51:
                        square.Row = 6;
                        square.Column = 6;
                        square.Region = 5;
                        break;
                    case 52:
                        square.Row = 6;
                        square.Column = 7;
                        square.Region = 6;
                        break;
                    case 53:
                        square.Row = 6;
                        square.Column = 8;
                        square.Region = 6;
                        break;
                    case 54:
                        square.Row = 6;
                        square.Column = 9;
                        square.Region = 6;
                        break;


                    //---------------------- Row 7 ----------------------
                    case 55:
                        square.Row = 7;
                        square.Column = 1;
                        square.Region = 7;
                        break;
                    case 56:
                        square.Row = 7;
                        square.Column = 2;
                        square.Region = 7;
                        break;
                    case 57:
                        square.Row = 7;
                        square.Column = 3;
                        square.Region = 7;
                        break;
                    case 58:
                        square.Row = 7;
                        square.Column = 4;
                        square.Region = 8;
                        break;
                    case 59:
                        square.Row = 7;
                        square.Column = 5;
                        square.Region = 8;
                        break;
                    case 60:
                        square.Row = 7;
                        square.Column = 6;
                        square.Region = 8;
                        break;
                    case 61:
                        square.Row = 7;
                        square.Column = 7;
                        square.Region = 9;
                        break;
                    case 62:
                        square.Row = 7;
                        square.Column = 8;
                        square.Region = 9;
                        break;
                    case 63:
                        square.Row = 7;
                        square.Column = 9;
                        square.Region = 9;
                        break;


                    //---------------------- Row 8 ----------------------
                    case 64:
                        square.Row = 8;
                        square.Column = 1;
                        square.Region = 7;
                        break;
                    case 65:
                        square.Row = 8;
                        square.Column = 2;
                        square.Region = 7;
                        break;
                    case 66:
                        square.Row = 8;
                        square.Column = 3;
                        square.Region = 7;
                        break;
                    case 67:
                        square.Row = 8;
                        square.Column = 4;
                        square.Region = 8;
                        break;
                    case 68:
                        square.Row = 8;
                        square.Column = 5;
                        square.Region = 8;
                        break;
                    case 69:
                        square.Row = 8;
                        square.Column = 6;
                        square.Region = 8;
                        break;
                    case 70:
                        square.Row = 8;
                        square.Column = 7;
                        square.Region = 9;
                        break;
                    case 71:
                        square.Row = 8;
                        square.Column = 8;
                        square.Region = 9;
                        break;
                    case 72:
                        square.Row = 8;
                        square.Column = 9;
                        square.Region = 9;
                        break;


                    //---------------------- Row 9 ----------------------
                    case 73:
                        square.Row = 9;
                        square.Column = 1;
                        square.Region = 7;
                        break;
                    case 74:
                        square.Row = 9;
                        square.Column = 2;
                        square.Region = 7;
                        break;
                    case 75:
                        square.Row = 9;
                        square.Column = 3;
                        square.Region = 7;
                        break;
                    case 76:
                        square.Row = 9;
                        square.Column = 4;
                        square.Region = 8;
                        break;
                    case 77:
                        square.Row = 9;
                        square.Column = 5;
                        square.Region = 8;
                        break;
                    case 78:
                        square.Row = 9;
                        square.Column = 6;
                        square.Region = 8;
                        break;
                    case 79:
                        square.Row = 9;
                        square.Column = 7;
                        square.Region = 9;
                        break;
                    case 80:
                        square.Row = 9;
                        square.Column = 8;
                        square.Region = 9;
                        break;
                    case 81:
                        square.Row = 9;
                        square.Column = 9;
                        square.Region = 9;
                        break;
                    default:
                        break;
                }
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
            SudokuSquare square = Squares.FirstOrDefault(s => s.Row == row && s.Column==column);
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
    }
}
